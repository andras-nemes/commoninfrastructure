using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Cryptography.Asymmetric;
using MyCompany.Infrastructure.Common.Cryptography.Hashing;

namespace MyCompany.Infrastructure.Common.Cryptography.DigitalSignature
{
	public class RsaPkcs1DigitalSignatureService : IEncryptedDigitalSignatureService
	{
		private readonly IHashingService _hashingService;

		public RsaPkcs1DigitalSignatureService(IHashingService hashingService)
		{
			if (hashingService == null) throw new ArgumentNullException("Hashing service");
			_hashingService = hashingService;
		}

		public DigitalSignatureCreationResult Sign(DigitalSignatureCreationArguments arguments)
		{
			DigitalSignatureCreationResult res = new DigitalSignatureCreationResult();

			try
			{				
				RSACryptoServiceProvider rsaProviderReceiver = new RSACryptoServiceProvider();
				rsaProviderReceiver.FromXmlString(arguments.PublicKeyForEncryption.ToString());
				byte[] encryptionResult = rsaProviderReceiver.Encrypt(Encoding.UTF8.GetBytes(arguments.Message), false);
				HashResult hashed = _hashingService.Hash(Convert.ToBase64String(encryptionResult));

				RSACryptoServiceProvider rsaProviderSender = new RSACryptoServiceProvider();
				rsaProviderSender.FromXmlString(arguments.FullKeyForSignature.ToString());
				RSAPKCS1SignatureFormatter signatureFormatter = new RSAPKCS1SignatureFormatter(rsaProviderSender);
				signatureFormatter.SetHashAlgorithm(_hashingService.HashAlgorithmCode());
				byte[] signature = signatureFormatter.CreateSignature(hashed.HashedBytes);

				res.Signature = signature;
				res.CipherText = Convert.ToBase64String(encryptionResult);
				res.Success = true;
			}
			catch (Exception ex)
			{
				res.ExceptionMessage = ex.Message;
			}

			return res;
		}

		public DigitalSignatureVerificationResult VerifySignature(DigitalSignatureVerificationArguments arguments)
		{
			DigitalSignatureVerificationResult res = new DigitalSignatureVerificationResult();

			try
			{
				RSACryptoServiceProvider rsaProviderSender = new RSACryptoServiceProvider();
				rsaProviderSender.FromXmlString(arguments.PublicKeyForSignatureVerification.ToString());
				RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(rsaProviderSender);
				deformatter.SetHashAlgorithm(_hashingService.HashAlgorithmCode());				
				HashResult hashResult = _hashingService.Hash(arguments.CipherText);
				res.SignaturesMatch = deformatter.VerifySignature(hashResult.HashedBytes, arguments.Signature);

				if (res.SignaturesMatch)
				{
					RSACryptoServiceProvider rsaProviderReceiver = new RSACryptoServiceProvider();
					rsaProviderReceiver.FromXmlString(arguments.FullKeyForDecryption.ToString());
					byte[] decryptedBytes = rsaProviderReceiver.Decrypt(Convert.FromBase64String(arguments.CipherText), false);
					res.DecodedText = Encoding.UTF8.GetString(decryptedBytes);
				}

				res.Success = true;
			}
			catch (Exception ex)
			{
				res.ExceptionMessage = ex.Message;
			}

			return res;
		}
	}
}
