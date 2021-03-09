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
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImage
    {
        ICarImageDal _carImageDal;
        ICarImage _carImageService;
        public CarImageManager(ICarImageDal carImageDal, ICarImage carImageService)
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
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetImagesById(int id)
        {
            throw new NotImplementedException();
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
        }
    
    }


