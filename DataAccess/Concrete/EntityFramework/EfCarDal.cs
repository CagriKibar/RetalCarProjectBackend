using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecaptProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(RecaptProjectContext context=new RecaptProjectContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId=p.CarId,
                                 CarName=p.CarName,
                                 BrandName=p.BrandName,
                              

                             };
                return result.ToList();
            }
        }
    }
}
