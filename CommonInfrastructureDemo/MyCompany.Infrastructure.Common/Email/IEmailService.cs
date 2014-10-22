using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Email
{
	public interface IEmailService
	{
		EmailSendingResult SendEmail(EmailArguments emailArguments);
	}
}
