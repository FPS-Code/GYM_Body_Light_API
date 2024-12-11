using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.Data;
using GYM_Body_Light_API.Src.DTOs;
using GYM_Body_Light_API.Src.Interfaces;
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
    }
}