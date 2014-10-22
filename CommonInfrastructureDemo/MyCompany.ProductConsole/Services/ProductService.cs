using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Caching;
using MyCompany.Infrastructure.Common.Configuration;
using MyCompany.ProductConsole.Domains;

namespace MyCompany.ProductConsole.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IConfigurationRepository _configurationRepository;

		public ProductService(IProductRepository productRepository, IConfigurationRepository configurationRepository)
		{
			if (productRepository == null) throw new ArgumentNullException("ProductRepository");
			if (configurationRepository == null) throw new ArgumentNullException("ConfigurationRepository");
			_productRepository = productRepository;
			_configurationRepository = configurationRepository;
		}

		public GetProductResponse GetProduct(GetProductRequest getProductRequest)
		{
			LogProviderContext.Current.LogInfo(this, "Log message from the contextual log provider");
			GetProductResponse response = new GetProductResponse();
			try
			{
				bool returnDefault = _configurationRepository.GetConfigurationValue<bool>("returnDefaultProduct", false);
				Product p = returnDefault ? BuildDefaultProduct() : _productRepository.FindBy(getProductRequest.Id);
				response.Product = p;
				if (p != null)
				{
					response.Success = true;
				}
				else
				{
					response.Exception = "No such product.";
				}
			}
			catch (Exception ex)
			{
				response.Exception = ex.Message;
			}
			return response;
		}

		private Product BuildDefaultProduct()
		{
			Product defaultProduct = new Product();
			defaultProduct.Id = _configurationRepository.GetConfigurationValue<int>("defaultProductId");
			defaultProduct.Name = _configurationRepository.GetConfigurationValue<string>("defaultProductName");
			defaultProduct.OnStock = _configurationRepository.GetConfigurationValue<int>("defaultProductQuantity");
			return defaultProduct;
		}
	}
}
