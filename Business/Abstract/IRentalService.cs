﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.AbstractValidator
{
   public interface IRentalService
    {
       IDataResult< List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto();
        IDataResult<Rental> GetById(int id);
       IResult  Add(Rental rental);
       IResult  Update(Rental rental);
       IResult  Delete(Rental rental);
    }
}
