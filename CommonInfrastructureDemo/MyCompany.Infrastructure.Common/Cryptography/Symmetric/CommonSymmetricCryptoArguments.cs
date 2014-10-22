using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public class CommonSymmetricCryptoArguments
	{
		public int KeySize { get; set; }
		public int BlockSize { get; set; }
		public PaddingMode PaddingMode { get; set; }
		public CipherMode CipherMode { get; set; }
		public string SymmetricPublicKey { get; set; }
	}
}
