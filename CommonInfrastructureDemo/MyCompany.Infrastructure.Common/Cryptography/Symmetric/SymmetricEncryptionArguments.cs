using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public class SymmetricEncryptionArguments : CommonSymmetricCryptoArguments
	{
		public string PlainText { get; set; }		
	}
}
