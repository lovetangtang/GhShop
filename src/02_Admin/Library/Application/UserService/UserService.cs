using Domain.Authenticate;
using EFCore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class UserService : IUserService
    {
        private ApiDBContent _dbContext = null;
        public UserService(ApiDBContent dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<BaseUser> GetNumberList()
        {
            _dbContext = _dbContext.ToRead();
            return _dbContext.BaseUser.Take(2).ToList();
        }

        public bool IsValid(LoginRequestDTO req)
        {
          
            return true;
        }
    }
}
