using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Caching;
using MyCompany.Infrastructure.Common.Configuration;
using MyCompany.Infrastructure.Common.ContextProvider;
using MyCompany.Infrastructure.Common.Cryptography;
using MyCompany.Infrastructure.Common.Cryptography.Asymmetric;
using MyCompany.Infrastructure.Common.Cryptography.DigitalSignature;
using MyCompany.Infrastructure.Common.Cryptography.Hashing;
using MyCompany.Infrastructure.Common.Cryptography.Symmetric;
using MyCompany.Infrastructure.Common.Logging;
using MyCompany.ProductConsole.Repositories;
using MyCompany.ProductConsole.Services;

namespace MyCompany.ProductConsole
{
	class Program
	{
		static void Main(string[] args)
		{	
			/*
			IConfigurationRepository configurationRepository = new ConfigFileConfigurationRepository();
			IProductService productService = new ProductService(new ProductRepository(), configurationRepository);
			IProductService cachedProductService = new CachedProductService(productService, new SystemRuntimeCacheStorage());
			ILoggingService loggingService = new Log4NetLoggingService(configurationRepository, new ThreadContextService());
			LogProviderContext.Current = loggingService;
			IProductService loggedCachedProductService = new LoggedProductService(cachedProductService, loggingService);

			GetProductResponse getProductResponse = loggedCachedProductService.GetProduct(new GetProductRequest() { Id = 2 });
			if (getProductResponse.Success)
			{
				Console.WriteLine(string.Concat("Product name: ", getProductResponse.Product.Name));
			}
			else
			{
				Console.WriteLine(getProductResponse.Exception);
			}

			//getProductResponse = loggedCachedProductService.GetProduct(new GetProductRequest() { Id = 2 });
			*/
			//TestSymmetricEncryptionService();
			TestAsymmetricEncryptionService();
			//TestDigitalSignatureService();

			Console.ReadKey();
		}

		private static void TestDigitalSignatureService()
		{
			IAsymmetricCryptographyService asymmetricService = new RsaAsymmetricCryptographyService();
			AsymmetricKeyPairGenerationResult keyPairGenerationResultReceiver = asymmetricService.GenerateAsymmetricKeys(1024);
			AsymmetricKeyPairGenerationResult keyPairGenerationResultSender = asymmetricService.GenerateAsymmetricKeys(1024);

			IEncryptedDigitalSignatureService digitalSignatureService = new RsaPkcs1DigitalSignatureService(new Sha1ManagedHashingService());

			DigitalSignatureCreationArguments signatureCreationArgumentsFromSender = new DigitalSignatureCreationArguments()
			{
				Message = "Text to be encrypted and signed"
				, FullKeyForSignature = keyPairGenerationResultSender.FullKeyPairXml
				, PublicKeyForEncryption = keyPairGenerationResultReceiver.PublicKeyOnlyXml
			};
			DigitalSignatureCreationResult signatureCreationResult = digitalSignatureService.Sign(signatureCreationArgumentsFromSender);
			if (signatureCreationResult.Success)
			{
				DigitalSignatureVerificationArguments verificationArgumentsFromReceiver = new DigitalSignatureVerificationArguments();
				verificationArgumentsFromReceiver.CipherText = signatureCreationResult.CipherText;
				verificationArgumentsFromReceiver.Signature = signatureCreationResult.Signature;
				verificationArgumentsFromReceiver.PublicKeyForSignatureVerification = keyPairGenerationResultSender.PublicKeyOnlyXml;
				verificationArgumentsFromReceiver.FullKeyForDecryption = keyPairGenerationResultReceiver.FullKeyPairXml;
				DigitalSignatureVerificationResult verificationResult = digitalSignatureService.VerifySignature(verificationArgumentsFromReceiver);
				if (verificationResult.Success)
				{
					if (verificationResult.SignaturesMatch)
					{
						Console.WriteLine("Signatures match, decoded text: {0}", verificationResult.DecodedText);
					}
					else
					{
						Console.WriteLine("Signature mismatch!!");
					}
				}
				else
				{
					Console.WriteLine("Signature verification failed: {0}", verificationResult.ExceptionMessage);
				}
			}
			else
			{
				Console.WriteLine("Signature creation failed: {0}", signatureCreationResult.ExceptionMessage);
			}
		}

		private static void TestSymmetricEncryptionService()
		{
			ISymmetricCryptographyService symmetricService = new RijndaelManagedSymmetricEncryptionService();
			SymmetricKeyGenerationResult validKey = symmetricService.GenerateSymmetricKey(128);
			if (validKey.Success)
			{
				Console.WriteLine("Key used for symmetric encryption: {0}", validKey.SymmetricKey);

				SymmetricEncryptionArguments encryptionArgs = new SymmetricEncryptionArguments()
				{
					BlockSize = 128
					,CipherMode = System.Security.Cryptography.CipherMode.CBC
					,KeySize = 256
					,PaddingMode = System.Security.Cryptography.PaddingMode.ISO10126
					,PlainText = "Text to be encoded"
					,SymmetricPublicKey = validKey.SymmetricKey
				};

				SymmetricEncryptionResult encryptionResult = symmetricService.Encrypt(encryptionArgs);

				if (encryptionResult.Success)
				{
					Console.WriteLine("Cipher text from encryption: {0}", encryptionResult.CipherText);
					Console.WriteLine("Initialisation vector from encryption: {0}", encryptionResult.InitialisationVector);
					SymmetricDecryptionArguments decryptionArgs = new SymmetricDecryptionArguments()
					{
						BlockSize = encryptionArgs.BlockSize
						,CipherMode = encryptionArgs.CipherMode
						,CipherTextBase64Encoded = encryptionResult.CipherText
						,InitialisationVectorBase64Encoded = encryptionResult.InitialisationVector
						,KeySize = encryptionArgs.KeySize
						,PaddingMode = encryptionArgs.PaddingMode
						,SymmetricPublicKey = validKey.SymmetricKey
					};
					CipherTextDecryptionResult decryptionResult = symmetricService.Decrypt(decryptionArgs);
					if (decryptionResult.Success)
					{
						Console.WriteLine("Decrypted text: {0}", decryptionResult.DecodedText);
					}
					else
					{
						Console.WriteLine("Decryption failure: {0}", decryptionResult.ExceptionMessage);
					}
				}
				else
				{
					Console.WriteLine("Encryption failure: {0}", encryptionResult.ExceptionMessage);
				}
			}
			else
			{
				Console.WriteLine("Symmetric key generation failure: {0}", validKey.ExceptionMessage);
			}
		}

		private static void TestAsymmetricEncryptionService()
		{
			IAsymmetricCryptographyService asymmetricSevice = new RsaAsymmetricCryptographyService();
			AsymmetricKeyPairGenerationResult keyPairGenerationResult = asymmetricSevice.GenerateAsymmetricKeys(1024);
			if (keyPairGenerationResult.Success)
			{
				AsymmetricEncryptionArguments encryptionArgs = new AsymmetricEncryptionArguments()
				{
					PlainText = "Text to be encrypted"
					, PublicKeyForEncryption = keyPairGenerationResult.PublicKeyOnlyXml
				};
				AsymmetricEncryptionResult encryptionResult = asymmetricSevice.Encrypt(encryptionArgs);
				if (encryptionResult.Success)
				{
					Console.WriteLine("Ciphertext: {0}", encryptionResult.CipherText);
					AsymmetricDecryptionArguments decryptionArguments = new AsymmetricDecryptionArguments()
					{
						CipherText = encryptionResult.CipherText
						, FullAsymmetricKey = keyPairGenerationResult.FullKeyPairXml
					};
					CipherTextDecryptionResult decryptionResult = asymmetricSevice.Decrypt(decryptionArguments);
					if (decryptionResult.Success)
					{
						Console.WriteLine("Decrypted text: {0}", decryptionResult.DecodedText);
					}
					else
					{
						Console.WriteLine("Decryption failure: {0}", decryptionResult.ExceptionMessage);
					}
				}
				else
				{
					Console.WriteLine("Encryption failure: {0}", encryptionResult.ExceptionMessage);
				}
			}
			else
			{
				Console.WriteLine("Asymmetric key generation failure: {0}", keyPairGenerationResult.ExceptionMessage);
			}
		}
	}
}
