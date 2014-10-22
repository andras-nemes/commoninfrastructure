using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Hashing
{
	public class Sha512ManagedHashingService : IHashingService
	{
		public HashResult Hash(string message)
		{
			HashResult hashResult = new HashResult();
			try
			{
				SHA512Managed sha512 = new SHA512Managed();
				byte[] hashed = sha512.ComputeHash(Encoding.UTF8.GetBytes(message));
				string hex = Convert.ToBase64String(hashed);
				hashResult.HashedBytes = hashed;
				hashResult.HexValueOfHash = hex;
			}
			catch (Exception ex)
			{
				hashResult.ExceptionMessage = ex.Message;
			}
			return hashResult;
		}

		public string HashAlgorithmCode()
		{
			return "SHA512";
		}
	}
}
