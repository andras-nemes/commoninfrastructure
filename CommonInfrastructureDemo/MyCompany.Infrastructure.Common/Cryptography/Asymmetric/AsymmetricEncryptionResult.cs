using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Asymmetric
{
	public class AsymmetricEncryptionResult : ResponseBase
	{
		public string CipherText { get; set; }
		public byte[] CipherBytes { get; set; }
	}
}
