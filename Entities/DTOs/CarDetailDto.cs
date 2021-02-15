using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTOs
{
  public class CarDetailDto: IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public short DailyPrice { get; set; }
    }
}
