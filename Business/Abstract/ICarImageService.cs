using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImage
    {
        IResult Add(CarImage carImage, IFormFile file);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage image, IFormFile file);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesById(int id);
    }
}
