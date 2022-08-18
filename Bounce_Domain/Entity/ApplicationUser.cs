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
        //[ForeignKey(nameof(ProfileId))]
        [JsonIgnore]
        public BioData Profile { get; set; }
        public string? PatientId { get; set; }
        public UserType Discriminator { get; set; }

    }
}
