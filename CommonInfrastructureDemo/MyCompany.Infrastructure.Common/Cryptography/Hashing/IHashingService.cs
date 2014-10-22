using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Hashing
{
	public interface IHashingService
	{
		HashResult Hash(string message);
		string HashAlgorithmCode();
	}
}
