using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.Models;

namespace GYM_Body_Light_API.Src.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser();
        Task<User> UpdateUser(User user);
    }
}