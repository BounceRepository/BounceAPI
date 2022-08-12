using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.DTO
{
    public class ConfirmEmailDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
