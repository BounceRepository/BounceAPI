using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class SignInLog
    {
        [Key]
        public Guid Id { get; set; }
        public string? RequestId { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? IPAddress { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public DateTime Date { get; set; }
    }
}
