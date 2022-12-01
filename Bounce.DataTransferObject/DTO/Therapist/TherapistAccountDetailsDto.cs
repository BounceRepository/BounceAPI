﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Therapist
{
    public class TherapistAccountDetailsDto
    {
        [Required]
      
        public string AccountName { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Account number must be 11 digits")]
        [MinLength(11, ErrorMessage = "Account number must be 11 digits")]
        public string AccountNumber { get; set; }
        [Required]
        public string BankName { get; set; }

    }
}