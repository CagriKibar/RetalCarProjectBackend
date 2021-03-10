
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
        void Add(User user);
    }
}
