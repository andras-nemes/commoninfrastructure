using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.ProductConsole.Domains;

namespace MyCompany.ProductConsole.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public Product FindBy(int id)
		{
			return (from p in AllProducts() where p.Id == id select p).FirstOrDefault();
		}

		private IEnumerable<Product> AllProducts()
		{
			return new List<Product>()
			{
				new Product(){Id = 1, Name = "Chair", OnStock = 10}
				, new Product(){Id = 2, Name = "Desk", OnStock = 20}
				, new Product(){Id = 3, Name = "Cupboard", OnStock = 15}
			};
		}
	}
}
