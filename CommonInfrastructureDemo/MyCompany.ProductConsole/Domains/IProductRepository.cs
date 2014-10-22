using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.ProductConsole.Domains
{
	public interface IProductRepository
	{
		Product FindBy(int id);
	}
}
