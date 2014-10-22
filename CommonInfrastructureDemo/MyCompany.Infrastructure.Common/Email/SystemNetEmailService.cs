using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Email
{
	public class SystemNetEmailService : IEmailService
	{
		public EmailSendingResult SendEmail(EmailArguments emailArguments)
		{
			EmailSendingResult sendResult = new EmailSendingResult();
			sendResult.EmailSendingFailureMessage = string.Empty;
			try
			{
				MailMessage mailMessage = new MailMessage(emailArguments.From, emailArguments.To);
				mailMessage.Subject = emailArguments.Subject;
				mailMessage.Body = emailArguments.Message;
				mailMessage.IsBodyHtml = emailArguments.Html;
				SmtpClient client = new SmtpClient(emailArguments.SmtpServer);

				if (emailArguments.EmbeddedResources != null && emailArguments.EmbeddedResources.Count > 0)
				{
					AlternateView avHtml = AlternateView.CreateAlternateViewFromString(emailArguments.Message, Encoding.UTF8, MediaTypeNames.Text.Html);
					foreach (EmbeddedEmailResource resource in emailArguments.EmbeddedResources)
					{
						LinkedResource linkedResource = new LinkedResource(resource.ResourceStream, resource.ResourceType.ToSystemNetResourceType());
						linkedResource.ContentId = resource.EmbeddedResourceContentId;
						avHtml.LinkedResources.Add(linkedResource);
					}
					mailMessage.AlternateViews.Add(avHtml);
				}

				client.Send(mailMessage);
				sendResult.EmailSentSuccessfully = true;
			}
			catch (Exception ex)
			{
				sendResult.EmailSendingFailureMessage = ex.Message;
			}

			return sendResult;
		}
	}
}
