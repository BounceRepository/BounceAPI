using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public  class UpdateProfileDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        //[Required]
        //public string MeansOfIdentification { get; set; }
        //[Required]
        [DataType(DataType.Upload)]
    
        public IFormFile? ImageFile { get; set; }
        //[Required]
        //public string UserId { get; set; }
        //[Required]
        [DataType(DataType.Upload)]
        public IFormFile ? MeansOfIdentification { get; set; }

        public string? PhysicalHealthRate { get; set; }
        public string? MentalHealthRate { get; set; }
        public string? EmotionalHealthRate { get; set; }
        public string? EatingHabit { get; set; }
    }
}
