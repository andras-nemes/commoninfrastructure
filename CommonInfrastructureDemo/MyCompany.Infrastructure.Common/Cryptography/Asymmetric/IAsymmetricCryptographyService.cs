using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Cryptography.Asymmetric;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public interface IAsymmetricCryptographyService
	{
		AsymmetricKeyPairGenerationResult GenerateAsymmetricKeys(int keySizeInBits);
		AsymmetricEncryptionResult Encrypt(AsymmetricEncryptionArguments arguments);
		CipherTextDecryptionResult Decrypt(AsymmetricDecryptionArguments arguments);
	}
}
