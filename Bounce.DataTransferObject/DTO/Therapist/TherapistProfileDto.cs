using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Therapist
{
    public class TherapistProfileDto
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? AboutMe { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? Specialization { get; set; }


        [Required]
        public int YearsOfExperience { get; set; }
        [Required]
        public string[] ConsultationDays { get; set; }
        [Required]
        public string? ConsultationStartTime { get; set; }
        [Required]
        public string? ConsultationEndTime { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
