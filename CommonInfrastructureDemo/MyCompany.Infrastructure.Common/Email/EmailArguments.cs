using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Email
{
	public class EmailArguments
	{
		private string _subject;
		private string _message;
		private string _to;
		private string _from;
		private string _smtpServer;
		private bool _html;

		/// <summary>
		/// A simple class holding the various arguments needed for sending emails
		/// </summary>
		/// <param name="subject">Email subject</param>
		/// <param name="message">Email message</param>
		/// <param name="to">Email recipient. If many, then delimit them with ';'</param>
		/// <param name="from">Email sender</param>
		/// <param name="smtpServer">Smtp server</param>
		public EmailArguments(string subject, string message, string to, string from, string smtpServer, bool html)
		{
			if (string.IsNullOrEmpty(subject))
				throw new ArgumentNullException("Email subject");
			if (string.IsNullOrEmpty(message))
				throw new ArgumentNullException("Email message");
			if (string.IsNullOrEmpty(to))
				throw new ArgumentNullException("Email recipient");
			if (string.IsNullOrEmpty(from))
				throw new ArgumentNullException("Email sender");
			if (string.IsNullOrEmpty(smtpServer))
				throw new ArgumentNullException("Smtp server");
			this._from = from;
			this._message = message;
			this._smtpServer = smtpServer;
			this._subject = subject;
			this._to = to;
			this._html = html;
		}

		public List<EmbeddedEmailResource> EmbeddedResources { get; set; }

		public string To
		{
			get
			{
				return this._to;
			}
		}

		public string From
		{
			get
			{
				return this._from;
			}
		}

		public string Subject
		{
			get
			{
				return this._subject;
			}
		}

		public string SmtpServer
		{
			get
			{
				return this._smtpServer;
			}
		}

		public string Message
		{
			get
			{
				return this._message;
			}
		}

		public bool Html
		{
			get
			{
				return this._html;
			}
		}
	}
}
