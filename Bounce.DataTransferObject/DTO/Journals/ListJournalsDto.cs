using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Journal
{
    public class ListJournalsDto
    {
        public long JournalId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
