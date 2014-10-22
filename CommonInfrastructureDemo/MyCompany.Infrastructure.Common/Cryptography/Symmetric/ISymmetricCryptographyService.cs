using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Cryptography.Symmetric;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public interface ISymmetricCryptographyService
	{
		SymmetricKeyGenerationResult GenerateSymmetricKey(int bitSize);
		SymmetricEncryptionResult Encrypt(SymmetricEncryptionArguments arguments);
		CipherTextDecryptionResult Decrypt(SymmetricDecryptionArguments arguments);
	}
}
