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
                             join d in context.Colors
                             on p.ColorId equals d.ColorId
                             select new CarDetailDto
                             {
                                 CarId=p.CarId,
                                 CarName=p.CarName,
                                 BrandName=b.BrandName,
                                 ColorName=d.ColorName,
                                 Description=p.Description,
                                 DailyPrice=p.DailyPrice,
                                 ModelYear=p.ModelYear,
                                 ImagePath = (from i in context.CarImages where i.CarId == p.CarId select i.ImagePath).FirstOrDefault()


                             };
                return result.ToList();
            }
        }
    }
}
