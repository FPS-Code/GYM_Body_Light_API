using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.DTOs;
using GYM_Body_Light_API.Src.Models;

namespace GYM_Body_Light_API.Src.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Verifica si un usuario con el correo electrónico especificado ya existe.
        /// </summary>
        /// <param name="email">Correo electrónico a verificar.</param>
        /// <returns>True si el usuario existe, de lo contrario false.</returns>
        Task<bool> UserExists(string email);

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="user">Modelo de usuario con los datos a registrar.</param>
        Task CreateUserAsync(User user);

        /// <summary>
        /// Genera un hash seguro para la contraseña proporcionada.
        /// </summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>Hash en formato base64.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Valida las credenciales de inicio de sesión de un usuario.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>El usuario si las credenciales son correctas, de lo contrario null.</returns>
        

        Task<User> RegisterUser(RegisterDto registerDto);

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<User?> ValidateCredentials(string email, string password);

        Task<IEnumerable<UserDto>> SearchUsersByNameAsync(string name);
        Task<bool> DeleteUserByEmailAsync(string email);

        Task<UserDto?> UpdateUserAsync(string email, UserDto updatedUserDto);
    }
    
}