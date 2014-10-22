using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Infrastructure.Common.Cryptography.Symmetric;

namespace MyCompany.Infrastructure.Common.Cryptography
{
	public class RijndaelManagedSymmetricEncryptionService : ISymmetricCryptographyService
	{
		public SymmetricEncryptionResult Encrypt(SymmetricEncryptionArguments arguments)
		{			
			SymmetricEncryptionResult res = new SymmetricEncryptionResult();
			try
			{
				RijndaelManaged rijndael = CreateCipher(arguments);
				res.InitialisationVector = Convert.ToBase64String(rijndael.IV);
				ICryptoTransform cryptoTransform = rijndael.CreateEncryptor();
				byte[] plain = Encoding.UTF8.GetBytes(arguments.PlainText);
				byte[] cipherText = cryptoTransform.TransformFinalBlock(plain, 0, plain.Length);
				res.CipherText = Convert.ToBase64String(cipherText);				
				res.Success = true;
			}
			catch (Exception ex)
			{
				res.ExceptionMessage = ex.Message;
			}
			return res;
		}

		public CipherTextDecryptionResult Decrypt(SymmetricDecryptionArguments arguments)
		{
			CipherTextDecryptionResult res = new CipherTextDecryptionResult();
			try
			{
				RijndaelManaged cipher = CreateCipher(arguments);
				cipher.IV = Convert.FromBase64String(arguments.InitialisationVectorBase64Encoded);
				ICryptoTransform cryptTransform = cipher.CreateDecryptor();
				byte[] cipherTextBytes = Convert.FromBase64String(arguments.CipherTextBase64Encoded);
				byte[] plainText = cryptTransform.TransformFinalBlock(cipherTextBytes, 0, cipherTextBytes.Length);
				res.DecodedText = Encoding.UTF8.GetString(plainText);
				res.Success = true;
			}
			catch (Exception ex)
			{
				res.ExceptionMessage = ex.Message;
			}
			return res;
		}

		public SymmetricKeyGenerationResult GenerateSymmetricKey(int bitSize)
		{
			SymmetricKeyGenerationResult res = new SymmetricKeyGenerationResult();
			try
			{
				byte[] key = new byte[bitSize / 8];
				RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
				rng.GetBytes(key);
				res.SymmetricKey = BitConverter.ToString(key).Replace("-", string.Empty);
				res.Success = true;
			}
			catch (Exception ex)
			{
				res.ExceptionMessage = ex.Message;
			}
			return res;
		}

		private RijndaelManaged CreateCipher(CommonSymmetricCryptoArguments arguments)
		{
			RijndaelManaged cipher = new RijndaelManaged();
			cipher.KeySize = arguments.KeySize;
			cipher.BlockSize =  arguments.BlockSize;
			cipher.Padding = arguments.PaddingMode;
			cipher.Mode = arguments.CipherMode;
			byte[] key = HexToByteArray(arguments.SymmetricPublicKey);
			cipher.Key = key;
			return cipher;
		}

		private byte[] HexToByteArray(string hexString)
		{
			if (0 != (hexString.Length % 2))
			{
				throw new ApplicationException("Hex string must be multiple of 2 in length");
			}

			int byteCount = hexString.Length / 2;
			byte[] byteValues = new byte[byteCount];
			for (int i = 0; i < byteCount; i++)
			{
				byteValues[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}

			return byteValues;
		}		
	}
}
