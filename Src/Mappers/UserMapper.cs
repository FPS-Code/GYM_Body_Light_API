using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.Models;
using GYM_Body_Light_API.Src.DTOs;
namespace GYM_Body_Light_API.Src.Mappers
{
    public class UserMapper
    {
        public static UserDto MapToDTO(User user)
        {
            return new UserDto
            {
               
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                BirthDate = user.BirthDate,
                district = user.district,
                DateAdmission = user.DateAdmission

            };
        }
        public static User MapToModel(UserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = userDto.Role,
                BirthDate = userDto.BirthDate,
                district = userDto.district,
                DateAdmission = userDto.DateAdmission
            };
        }
    }
}