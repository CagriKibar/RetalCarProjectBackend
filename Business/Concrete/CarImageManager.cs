using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
       
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
           
        }

        [ValidationAspect(typeof(CarImageValidator))]
       // [SecuredOperation("admin")]
        public IResult Add(IFormFile file, CarImage carImage )
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result!=null)
            {
                //return new ErrorResult(Messages.ImgaesLimitError);
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            //FileHelper.Delete(carImage.ImagePath);
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result!=null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.DeletedCarImage);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(I => I.Id == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetImagesById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(I => I.CarId == id));

        }
       // [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            //IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            //if (result!=null)
            //{
            //    return result;
            //}
           
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidator))]
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImageCount>=5)
            {
                return new ErrorResult(Messages.ImgaesLimitError);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\wwwroot\uploads\logo.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carImages = new List<CarImage>();
                    carImages.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImages);
                }
            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<CarImage>>(e.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                FileHelper.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
    
    }


