using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.BaseModel
{
	public class BaseEntity
	{
		protected static int _idCounter { get; set; }
		public int Id { get; set; }
	}
}
