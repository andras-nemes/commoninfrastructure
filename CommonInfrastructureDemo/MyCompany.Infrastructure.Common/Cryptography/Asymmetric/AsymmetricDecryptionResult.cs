using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Asymmetric
{
	public class AsymmetricDecryptionResult : ResponseBase
	{
		public string DecodedText { get; set; }
	}
}
