using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Journal :BaseEntity
    {
       
        public string Title { get; set; }
        public string Text { get; set; }

        public long? CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        [JsonIgnore]
        public virtual ApplicationUser CreatedBy { get; set; }
    }
}
