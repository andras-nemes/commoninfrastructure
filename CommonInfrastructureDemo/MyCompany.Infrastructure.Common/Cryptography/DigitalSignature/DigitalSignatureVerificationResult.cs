using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.DigitalSignature
{
	public class DigitalSignatureVerificationResult : ResponseBase
	{
		public bool SignaturesMatch { get; set; }
		public string DecodedText { get; set; }
	}
}
