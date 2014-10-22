using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.DigitalSignature
{
	public class DigitalSignatureCreationResult : ResponseBase
	{
		public byte[] Signature { get; set; }
		public string CipherText { get; set; }
	}
}
