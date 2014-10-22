using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Email
{
	public class EmbeddedEmailResource
	{
		public EmbeddedEmailResource(Stream resourceStream, EmbeddedEmailResourceType resourceType
			, string embeddedResourceContentId)
		{
			if (resourceStream == null) throw new ArgumentNullException("Resource stream");
			if (String.IsNullOrEmpty(embeddedResourceContentId)) throw new ArgumentNullException("Resource content id");
			ResourceStream = resourceStream;
			ResourceType = resourceType;
			EmbeddedResourceContentId = embeddedResourceContentId;
		}

		public Stream ResourceStream { get; set; }
		public EmbeddedEmailResourceType ResourceType { get; set; }
		public string EmbeddedResourceContentId { get; set; }
	}
}
