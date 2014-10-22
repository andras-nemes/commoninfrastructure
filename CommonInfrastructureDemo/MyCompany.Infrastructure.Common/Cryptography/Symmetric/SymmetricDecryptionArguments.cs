using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public class SymmetricDecryptionArguments : CommonSymmetricCryptoArguments
	{
		public string CipherTextBase64Encoded { get; set; }
		public string InitialisationVectorBase64Encoded { get; set; }		
	}
}
