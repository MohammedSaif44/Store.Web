using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entity
{
	public class ProductBrand:BaseEntity<int>
	{
		public String Name { get; set; }
	}
}
