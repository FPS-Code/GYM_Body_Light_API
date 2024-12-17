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
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchUsersByName([FromQuery] string name)
        {
            var users = await _userService.SearchUsersByNameAsync(name);
            return Ok(users);
        }

        /// <summary>
        /// Elimina un usuario por correo electrónico.
        /// </summary>
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var deleted = await _userService.DeleteUserByEmailAsync(email);

            if (!deleted)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }

            return Ok(new { message = "Usuario eliminado exitosamente." });
        }

        /// <summary>
        /// Obtiene un usuario por correo electrónico.
        /// </summary>
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            if (!await _userService.UserExists(email))
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }

            // Aquí puedes retornar los detalles básicos del usuario si es necesario
            return Ok(new { message = "Usuario existe.", email });
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateUser(string email, [FromBody] UserDto updatedUserDto)
        {
            var updatedUser = await _userService.UpdateUserAsync(email, updatedUserDto);

            if (updatedUser == null)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }

            return Ok(new { message = "Usuario actualizado exitosamente.", updatedUser });
        }

        
    }
}