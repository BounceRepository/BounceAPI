using Bounce_Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class ApplicationUser : IdentityUser<long>
    {
       
        public bool HasProfile { get; set; }
        public long? ProfileId { get; set; }

        public string? PatientId { get; set; }
        public UserType Discriminator { get; set; }
        public string? NotificationToken { get; set; }
        public string? DeviceId { get; set; }
        public long? TherapistUserProfileId { get; set; }
        [ForeignKey(nameof(TherapistUserProfileId))]
        public virtual TherapistProfile TherapistProfile { get; set; }

        public long? PatientUserProfileId { get; set; }
        [ForeignKey(nameof(PatientUserProfileId))]
        public virtual UserProfile PatientProfile { get; set; }

        public virtual ICollection<TherapistReview> Review { get; set; }



    }
}
