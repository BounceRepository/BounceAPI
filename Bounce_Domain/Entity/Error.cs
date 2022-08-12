using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
	public class Error : BaseEntity
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public string DisplayMessage { get; set; }
	}
}
