using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.FileOperations
{
	public interface IFileService
	{		
		bool FileExists(string fileFullPath);		
		long LastModifiedDateUnix(string fileFullPath);		
		string RetrieveContentsAsBase64String(string fileFullPath);		
		byte[] ReadContentsOfFile(string fileFullPath);		
		string GetFileName(string fullFilePath);		
		bool SaveFileContents(string fileFullPath, byte[] contents);		
		bool SaveFileContents(string fileFullPath, string base64Contents);			
		string GetFileExtension(string fileName);		
		bool DeleteFile(string fileFullPath);
	}
}
