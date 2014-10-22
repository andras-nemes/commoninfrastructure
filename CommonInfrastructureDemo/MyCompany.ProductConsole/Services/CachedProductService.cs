using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Caching;
using MyCompany.ProductConsole.Domains;

namespace MyCompany.ProductConsole.Services
{
	public class CachedProductService : IProductService
	{
		private readonly IProductService _productService;
		private readonly ICacheStorage _cacheStorage;

		public CachedProductService(IProductService productService, ICacheStorage cacheStorage)
		{
			if (productService == null) throw new ArgumentNullException("ProductService");
			if (cacheStorage == null) throw new ArgumentNullException("CacheStorage");
			_cacheStorage = cacheStorage;
			_productService = productService;
		}

		public GetProductResponse GetProduct(GetProductRequest getProductRequest)
		{
			GetProductResponse response = new GetProductResponse();
			try
			{
				string storageKey = "GetProductById";
				Product p = _cacheStorage.Retrieve<Product>(storageKey);
				if (p == null)
				{
					response = _productService.GetProduct(getProductRequest);
					_cacheStorage.Store(storageKey, response.Product, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
				}
				else
				{
					response.Success = true;
					response.Product = p;
				}
			}
			catch (Exception ex)
			{
				response.Exception = ex.Message;
			}
			return response;
		}
	}
}
