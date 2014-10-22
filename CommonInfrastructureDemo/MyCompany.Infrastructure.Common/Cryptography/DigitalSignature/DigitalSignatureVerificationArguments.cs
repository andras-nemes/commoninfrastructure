using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCompany.Infrastructure.Common.Cryptography.DigitalSignature
{
	public class DigitalSignatureVerificationArguments
	{
		public XDocument PublicKeyForSignatureVerification { get; set; }
		public XDocument FullKeyForDecryption { get; set; }
		public string CipherText { get; set; }
		public byte[] Signature { get; set; }
	}
}
