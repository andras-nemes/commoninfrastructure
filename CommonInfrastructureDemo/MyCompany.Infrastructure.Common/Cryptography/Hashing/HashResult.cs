using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Cryptography.Hashing
{
	public class HashResult : ResponseBase
	{
		public string HexValueOfHash { get; set; }
		public byte[] HashedBytes { get; set; }
	}
}
