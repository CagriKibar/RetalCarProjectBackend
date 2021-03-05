using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
            image.ImagePath=File
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

        }
    }


