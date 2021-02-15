using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _car;
        public CarManager(ICarDal car)
        {
            _car = car;
        }
        public void Add(Car car)
        {

            if (car.DailyPrice>0)
            {
                _car.Add(car);
            }
            else
            {
                Console.WriteLine("Fiyat Bilgisi 0 Olamaz");
            }
            
           
        }

        public void Delete(Car car)
        {
            _car.Delete(car);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll());
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(c => c.DailyPrice == min));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails());
        }

        public void Update(Car car)
        {
            _car.Update(car);
            
        }
    }
}
