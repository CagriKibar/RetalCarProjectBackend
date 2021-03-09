using Core.Entities.Concrete;
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
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

    }
}
