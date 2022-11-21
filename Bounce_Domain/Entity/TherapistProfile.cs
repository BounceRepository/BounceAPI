using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class TherapistProfile : BaseEntity
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        //[Display(Name ="About me")]
        public string? Email { get; set; }
        public string? Descipline { get; set; }
        public string? PhoneNumber { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Specialization { get; set; }
        public string? YearsOfExperience { get; set; }
        public string? ConsultationDays { get; set; }
        public string?  ConsultationStartTime { get; set; }
        public string? ConsultationEndTime { get; set; }
        public string? ProfilePicture { get; set; }

        public double ServiceCharge { get; set; }

        public long? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

       


    }
}
