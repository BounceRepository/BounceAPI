using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class UpdateUserModeDto
    {
        [Required]
        public List<string> Mood { get; set; }
    }
}
