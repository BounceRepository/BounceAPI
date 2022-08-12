using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class BioData : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MeansOfIdentification { get; set; }
        public string FilePath { get; set; }
        public bool ActivatePinLock { get; set; }
        public bool BecomeAnonymous { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public  virtual ApplicationUser User { get; set; }

    }
}
