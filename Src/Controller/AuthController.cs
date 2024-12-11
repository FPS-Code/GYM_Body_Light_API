using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM_Body_Light_API.Src.DTOs;
using GYM_Body_Light_API.Src.Interfaces;
using GYM_Body_Light_API.Src.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Body_Light_API.Src.Controller
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService; // Servicio que maneja la autenticación y búsqueda de usuarios

        public AuthController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        // Ruta para el login
         [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // Validar credenciales usando el servicio
            var user = await _userService.ValidateCredentials(loginDto.Email, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Generar token JWT
            var token = _jwtService.GenerateToken(user.Email, user.Role);

            return Ok(new
            {
                Token = token,
                User = new
                {
                    user.Name,
                    user.LastName,
                    user.Email,
                    user.Role
                }
            });
        }

        // Ruta para el registro de usuario
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userService.UserExists(registerDto.Email);
            if (existingUser )
            {
                return Conflict("A user with this email already exists.");
            }

            var newUser = await _userService.RegisterUser(registerDto);
            return CreatedAtAction(nameof(Register), new { id = newUser.Id });
        }
    }
}