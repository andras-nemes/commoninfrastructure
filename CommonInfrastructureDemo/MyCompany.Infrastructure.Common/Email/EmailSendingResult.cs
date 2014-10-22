using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Email
{
	public class EmailSendingResult
	{
		public bool EmailSentSuccessfully { get; set; }
		public string EmailSendingFailureMessage { get; set; }
	}
}
