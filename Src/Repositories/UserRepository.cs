using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.Interfaces;
using GYM_Body_Light_API.Src.Models;
namespace GYM_Body_Light_API.Src.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}