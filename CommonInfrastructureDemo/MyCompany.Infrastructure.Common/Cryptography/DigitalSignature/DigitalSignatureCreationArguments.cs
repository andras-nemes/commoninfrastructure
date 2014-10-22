using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCompany.Infrastructure.Common.Cryptography.DigitalSignature
{
	public class DigitalSignatureCreationArguments
	{
		public string Message { get; set; }
		public XDocument FullKeyForSignature { get; set; }
		public XDocument PublicKeyForEncryption { get; set; }
	}
}
