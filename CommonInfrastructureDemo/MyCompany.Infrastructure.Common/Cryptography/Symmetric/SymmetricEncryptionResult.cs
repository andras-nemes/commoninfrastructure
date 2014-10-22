using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public class SymmetricEncryptionResult : ResponseBase
	{
		public string CipherText { get; set; }
		public string InitialisationVector { get; set; }		
	}
}
