using Business.Abstract;
using Business.Constants;
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
        ICarImageService _carImageService;
        public CarImageManager(ICarImageDal carImageDal, ICarImageService carImageService)
        {
            _carImageDal = carImageDal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) +
                _carImageDal.Get(I => I.Id == carImage.Id).ImagePath;
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedCarImage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(I => I.Id == id));
        }

      

        public IDataResult<CarImage> GetImagesById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(I => I.CarId == id));

        }

        public IResult Update(CarImage image, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            if (result!=null)
            {
                return result;
            }
           
            image.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == image.Id).ImagePath, file);
            image.Date = DateTime.Now;
            _carImageDal.Update(image);
            return new SuccessResult();
        }

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
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }
    }
    
    }


