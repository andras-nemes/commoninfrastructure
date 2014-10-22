using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Hashing
{
	public class Sha1ManagedHashingService : IHashingService
	{
		public HashResult Hash(string message)
		{
			HashResult hashResult = new HashResult();
			try
			{
				SHA1Managed sha1 = new SHA1Managed();
				byte[] hashed = sha1.ComputeHash(Encoding.UTF8.GetBytes(message));
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
			return "SHA1";
		}
	}
}
