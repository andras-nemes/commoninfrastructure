using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Email
{
	public static class EmailExtensions
	{
		public static string ToSystemNetResourceType(this EmbeddedEmailResourceType resourceTypeEnum)
		{
			string type = MediaTypeNames.Text.Plain;
			switch (resourceTypeEnum)
			{
				case EmbeddedEmailResourceType.Gif:
					type = MediaTypeNames.Image.Gif;
					break;
				case EmbeddedEmailResourceType.Jpg:
					type = MediaTypeNames.Image.Jpeg;
					break;
				case EmbeddedEmailResourceType.Html:
					type = MediaTypeNames.Text.Html;
					break;
				case EmbeddedEmailResourceType.OctetStream:
					type = MediaTypeNames.Application.Octet;
					break;
				case EmbeddedEmailResourceType.Pdf:
					type = MediaTypeNames.Application.Pdf;
					break;
				case EmbeddedEmailResourceType.Plain:
					type = MediaTypeNames.Text.Plain;
					break;
				case EmbeddedEmailResourceType.RichText:
					type = MediaTypeNames.Text.RichText;
					break;
				case EmbeddedEmailResourceType.Rtf:
					type = MediaTypeNames.Application.Rtf;
					break;
				case EmbeddedEmailResourceType.Soap:
					type = MediaTypeNames.Application.Soap;
					break;
				case EmbeddedEmailResourceType.Tiff:
					type = MediaTypeNames.Image.Tiff;
					break;
				case EmbeddedEmailResourceType.Xml:
					type = MediaTypeNames.Text.Xml;
					break;
				case EmbeddedEmailResourceType.Zip:
					type = MediaTypeNames.Application.Zip;
					break;
			}

			return type;
		}
	}
}
