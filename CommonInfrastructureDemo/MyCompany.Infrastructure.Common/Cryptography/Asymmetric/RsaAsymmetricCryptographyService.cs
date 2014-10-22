using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyCompany.Infrastructure.Common.Cryptography.Asymmetric;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public class RsaAsymmetricCryptographyService : IAsymmetricCryptographyService
	{
		public AsymmetricKeyPairGenerationResult GenerateAsymmetricKeys(int keySizeInBits)
		{
			try
			{
				RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider(keySizeInBits);
				XDocument publicKeyXml = XDocument.Parse(myRSA.ToXmlString(false));
				XDocument fullKeyXml = XDocument.Parse(myRSA.ToXmlString(true));
				return new AsymmetricKeyPairGenerationResult(fullKeyXml, publicKeyXml) { Success = true };
			}
			catch (Exception ex)
			{
				return new AsymmetricKeyPairGenerationResult(new XDocument(), new XDocument()) { ExceptionMessage = ex.Message };
			}
		}

		public AsymmetricEncryptionResult Encrypt(AsymmetricEncryptionArguments arguments)
		{
			AsymmetricEncryptionResult encryptionResult = new AsymmetricEncryptionResult();
			try
			{
				RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider();
				string rsaKeyForEncryption = arguments.PublicKeyForEncryption.ToString();
				myRSA.FromXmlString(rsaKeyForEncryption);
				byte[] data = Encoding.UTF8.GetBytes(arguments.PlainText);
				byte[] cipherText = myRSA.Encrypt(data, false);
				encryptionResult.CipherBytes = cipherText;
				encryptionResult.CipherText = Convert.ToBase64String(cipherText);
				encryptionResult.Success = true;
			}
			catch (Exception ex)
			{
				encryptionResult.ExceptionMessage = ex.Message;
			}
			return encryptionResult;
		}

		public CipherTextDecryptionResult Decrypt(AsymmetricDecryptionArguments arguments)
		{
			CipherTextDecryptionResult decryptionResult = new CipherTextDecryptionResult();
			try
			{
				RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
				cipher.FromXmlString(arguments.FullAsymmetricKey.ToString());
				byte[] original = cipher.Decrypt(Convert.FromBase64String(arguments.CipherText), false);
				decryptionResult.DecodedText = Encoding.UTF8.GetString(original);
				decryptionResult.Success = true;
			}
			catch (Exception ex)
			{
				decryptionResult.ExceptionMessage = ex.Message;
			}
			return decryptionResult;
		}
	}
}
