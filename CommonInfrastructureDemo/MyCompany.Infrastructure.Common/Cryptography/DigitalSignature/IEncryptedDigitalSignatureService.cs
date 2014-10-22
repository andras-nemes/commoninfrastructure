using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.DigitalSignature
{
	public interface IEncryptedDigitalSignatureService
	{
		DigitalSignatureCreationResult Sign(DigitalSignatureCreationArguments arguments);
		DigitalSignatureVerificationResult VerifySignature(DigitalSignatureVerificationArguments arguments);
	}
}
