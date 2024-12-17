using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.Data;
using GYM_Body_Light_API.Src.DTOs;
using GYM_Body_Light_API.Src.Interfaces;
using GYM_Body_Light_API.Src.Mappers;
using GYM_Body_Light_API.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace GYM_Body_Light_API.Src.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context; // Suponiendo que tienes un DbContext para la base de datos

        public UserService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        /// <inheritdoc />
        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        /// <inheritdoc />
        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        /// <inheritdoc />
        public async Task<User?> ValidateCredentials(string email, string password)
        {
            // Busca al usuario por correo electrónico
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null;
            }

            // Valida la contraseña
            var hashedPassword = HashPassword(password);
            if (user.Password == hashedPassword)
            {
                return user;
            }

            return null;
        }
        public async Task<User> RegisterUser(RegisterDto registerDto)
        {
            var newUser = new User
            {
                Name = registerDto.Name,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = HashPassword(registerDto.Password),
                Role = "User", // Asignar el rol por defecto
                District = registerDto.District,
                BirthDate = registerDto.BirthDate,
                DateAdmission = DateOnly.FromDateTime(DateTime.UtcNow) // Asignar la fecha actual
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();

            // Mapear usuarios a DTO usando el mapper
            return users.Select(UserMapper.ToDTO).ToList();
        }

        public async Task<IEnumerable<UserDto>> SearchUsersByNameAsync(string name)
        {
            var users = await _context.Users
                .Where(u => u.Name.Contains(name))
                .AsNoTracking()
                .ToListAsync();

            return users.Select(UserMapper.ToDTO).ToList();
        }
        public async Task<bool> DeleteUserByEmailAsync(string email)
        {
            // Buscar al usuario por su correo
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false; // Usuario no encontrado
            }

            // Eliminar el usuario si existe
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto?> UpdateUserAsync(string email, UserDto updatedUserDto)
        {
            // Buscar el usuario existente por correo
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return null; // Usuario no encontrado
            }

            // Actualizar los campos del usuario
            user.Name = updatedUserDto.Name;
            user.LastName = updatedUserDto.LastName;
            user.District = updatedUserDto.District;
            user.Role = updatedUserDto.Role;

            // Guardar los cambios en la base de datos
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            // Devolver el usuario actualizado como DTO
            return UserMapper.ToDTO(user);
        }

    }
}