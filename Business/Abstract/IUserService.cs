
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.AbstractValidator
{
   public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetAll();
        User GetByMail(string email);
        
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

    }
}
