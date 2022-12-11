using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Journal
{
    public class CreateJournalDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
