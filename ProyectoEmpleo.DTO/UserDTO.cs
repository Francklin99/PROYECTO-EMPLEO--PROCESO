using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.DTO
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "El formato de correo es incorrecto")]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;

    }
}
