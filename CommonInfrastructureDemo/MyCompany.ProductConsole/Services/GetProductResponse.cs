using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.ProductConsole.Domains;

namespace MyCompany.ProductConsole.Services
{
	public class GetProductResponse
	{
		public bool Success { get; set; }
		public string Exception { get; set; }
		public Product Product { get; set; }
	}
}
