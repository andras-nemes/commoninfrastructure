using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Symmetric
{
	public class SymmetricKeyGenerationResult : ResponseBase
	{
		public string SymmetricKey { get; set; }
	}
}
