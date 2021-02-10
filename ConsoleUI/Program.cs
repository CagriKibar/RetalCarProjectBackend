using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" Marka Id: "+car.BrandId+" - "+" Araba Id: "+ car.CarId+" ---"+" Araba Fiyatı: "+ car.DailyPrice );

            }
        }
    }
}
