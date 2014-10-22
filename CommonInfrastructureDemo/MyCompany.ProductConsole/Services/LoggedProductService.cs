using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Logging;

namespace MyCompany.ProductConsole.Services
{
	public class LoggedProductService : IProductService
	{
		private readonly IProductService _productService;
		private readonly ILoggingService _loggingService;

		public LoggedProductService(IProductService productService, ILoggingService loggingService)
		{
			if (productService == null) throw new ArgumentNullException("ProductService");
			if (loggingService == null) throw new ArgumentNullException("LoggingService");
			_productService = productService;
			_loggingService = loggingService;
		}

		public GetProductResponse GetProduct(GetProductRequest getProductRequest)
		{
			GetProductResponse response = new GetProductResponse();
			_loggingService.LogInfo(this, "Starting GetProduct method");
			try
			{
				response = _productService.GetProduct(getProductRequest);
				if (response.Success)
				{
					_loggingService.LogInfo(this, "GetProduct success!!!");
				}
				else
				{
					_loggingService.LogError(this, "GetProduct failure...", new Exception(response.Exception));
				}
			}
			catch (Exception ex)
			{
				response.Exception = ex.Message;
				_loggingService.LogError(this, "Exception in GetProduct!!!", ex);
			}
			return response;
		}
	}
}
