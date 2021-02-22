using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.AbstractValidator
{
   public interface IUserService
    {
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(User user);

    }
}
