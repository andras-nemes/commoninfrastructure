using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.FileOperations
{
	public class DefaultFileService : IFileService
	{
		public bool FileExists(string fileFullPath)
		{
			FileInfo fileInfo = new FileInfo(fileFullPath);
			return fileInfo.Exists;
		}

		public long LastModifiedDateUnix(string fileFullPath)
		{
			FileInfo fileInfo = new FileInfo(fileFullPath);
			if (fileInfo.Exists)
			{
				DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0);
				TimeSpan timeSpan = fileInfo.LastWriteTimeUtc - epoch;
				return Convert.ToInt64(timeSpan.TotalMilliseconds);
			}

			return -1;
		}

		public string RetrieveContentsAsBase64String(string fileFullPath)
		{
			byte[] contents = ReadContentsOfFile(fileFullPath);
			if (contents != null)
			{
				return Convert.ToBase64String(contents);
			}
			return string.Empty;
		}

		public byte[] ReadContentsOfFile(string fileFullPath)
		{
			FileInfo fi = new FileInfo(fileFullPath);
			if (fi.Exists)
			{
				return File.ReadAllBytes(fileFullPath);
			}

			return null;
		}

		public string GetFileName(string fullFilePath)
		{
			FileInfo fi = new FileInfo(fullFilePath);
			return fi.Name;
		}

		public bool SaveFileContents(string fileFullPath, byte[] contents)
		{
			try
			{
				File.WriteAllBytes(fileFullPath, contents);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveFileContents(string fileFullPath, string base64Contents)
		{
			return SaveFileContents(fileFullPath, Convert.FromBase64String(base64Contents));
		}

		public string GetFileExtension(string fileName)
		{
			FileInfo fi = new FileInfo(fileName);
			return fi.Extension;
		}

		public bool DeleteFile(string fileFullPath)
		{
			FileInfo fi = new FileInfo(fileFullPath);
			if (fi.Exists)
			{
				File.Delete(fileFullPath);
			}

			return true;
		}
	}
}
