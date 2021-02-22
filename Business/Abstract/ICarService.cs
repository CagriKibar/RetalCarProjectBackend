using Core.Utilities.Results;
using DataAccess.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.AbstractValidator
{
  public  interface ICarService
    {
       IDataResult< List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        
    }
}
