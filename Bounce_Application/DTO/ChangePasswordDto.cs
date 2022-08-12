using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.DTO
{
    public class ChangePasswordDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
     

    }
}
