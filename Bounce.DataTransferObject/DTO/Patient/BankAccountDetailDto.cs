using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class BankAccountDetailDto
    {
      
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string? AccountType { get; set; }
        [Required]
        public string? BankName { get; set; }
        [Required]
        public long TherapistId { get; set; }
    }
}
