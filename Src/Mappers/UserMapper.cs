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
        public static UserDto ToDTO(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                District = user.District,
                DateAdmission = user.DateAdmission
            };
        }

        public static User ToEntity(UserDto userDTO)
        {
            return new User
            {
                Name = userDTO.Name,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Role = userDTO.Role,
                District = userDTO.District,
                DateAdmission = userDTO.DateAdmission
            };
        }
    }
}