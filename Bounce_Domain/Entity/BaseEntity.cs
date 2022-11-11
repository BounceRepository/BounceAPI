using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
	public abstract class BaseEntity
	{
		protected BaseEntity()
		{
			DateCreated = DateTime.Now;
			DateModified = DateTime.Now;

		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public bool IsActive { get; set; }
		public string? LastModifiedBy { get; set; }
		public bool IsDeleted { get; set; }
		[Timestamp]
		public byte[] RowVersion { get; set; }
	}
}
