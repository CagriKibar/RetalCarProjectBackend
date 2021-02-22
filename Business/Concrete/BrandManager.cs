using Business.AbstractValidator;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;
        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length>=2)
            {
                _brand.Add(brand);

            }
            else
            {
                Console.WriteLine("Marka ismi hatalı veya iki karakterden az girdiniz...");
            }
        }

        public void Delete(Brand brand)
        {
            _brand.Delete(brand);

        }

        public List<Brand> GetAll()
        {
            return _brand.GetAll();
        }

        public void Update(Brand brand)
        {
            _brand.Update(brand);
        }
    }
}
