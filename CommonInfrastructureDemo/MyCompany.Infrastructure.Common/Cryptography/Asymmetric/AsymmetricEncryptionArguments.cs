using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCompany.Infrastructure.Common.Cryptography.Asymmetric
{
	public class AsymmetricEncryptionArguments
	{
		public XDocument PublicKeyForEncryption { get; set; }
		public string PlainText { get; set; }		
	}
}
