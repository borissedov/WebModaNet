using EW.WebModaNetClassLibrary.Entities;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace EW.WebModaNet.Code
{
	public static class Utils
	{
		public static bool ControllaPartitaIvaItaliana(string partitaIva)
		{
			bool isValid = false;
			if (Regex.IsMatch(partitaIva, "^\\d{11}$", RegexOptions.IgnoreCase))
			{
				char chr = partitaIva[0];
				int d1 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[1];
				int d2 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[2];
				int d3 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[3];
				int d4 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[4];
				int d5 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[5];
				int d6 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[6];
				int d7 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[7];
				int d8 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[8];
				int d9 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[9];
				int d10 = Convert.ToInt32(chr.ToString());
				chr = partitaIva[10];
				int d11 = Convert.ToInt32(chr.ToString());
				int x = d1 + d3 + d5 + d7 + d9;
				int y = 2 * (d2 + d4 + d6 + d8 + d10);
				int z = (d2 >= 5 ? 1 : 0) + (d4 >= 5 ? 1 : 0) + (d6 >= 5 ? 1 : 0) + (d8 >= 5 ? 1 : 0) + (d10 >= 5 ? 1 : 0);
				int t = (x + y + z) % 10;
				isValid = d11 == (10 - t) % 10;
			}
			return isValid;
		}

		public static void CopyContent(DirectoryInfo sourceDir, DirectoryInfo destDir)
		{
			int i;
			if (!Directory.Exists(destDir.FullName))
			{
				Directory.CreateDirectory(destDir.FullName);
			}
			FileInfo[] files = sourceDir.GetFiles();
			for (i = 0; i < (int)files.Length; i++)
			{
				FileInfo sourceFile = files[i];
				sourceFile.CopyTo(Path.Combine(destDir.FullName, sourceFile.Name), true);
			}
			DirectoryInfo[] directories = sourceDir.GetDirectories();
			for (i = 0; i < (int)directories.Length; i++)
			{
				DirectoryInfo sourceSubDir = directories[i];
				DirectoryInfo destSubDir = new DirectoryInfo(Path.Combine(destDir.FullName, sourceSubDir.Name));
				EW.WebModaNet.Code.Utils.CopyContent(sourceSubDir, destSubDir);
			}
		}

		public static void DownloadFile(string sourceUrl, string destPath)
		{
			WebClient webClient = new WebClient();
			try
			{
				webClient.DownloadFile(sourceUrl, destPath);
			}
			finally
			{
				if (webClient != null)
				{
					((IDisposable)webClient).Dispose();
				}
			}
		}

		public static string FormatNumber(decimal number, int places)
		{
			string str = string.Format(string.Concat("{0:N", places, "}"), number);
			return str;
		}

		public static string FormatNumber(decimal number, Agente agente)
		{
			return EW.WebModaNet.Code.Utils.FormatNumber(number, agente.NumeroDecimali);
		}

		public static string GetCodiceUtenteDefault()
		{
			string codiceUtente = string.Empty;
			string path = HttpContext.Current.Server.MapPath(WebConfigSettings.UserDataFile);
			if (File.Exists(path))
			{
				codiceUtente = XDocument.Load(path).Descendants("codiceUtente").Single<XElement>().Value;
			}
			return codiceUtente;
		}

		public static string GetMD5(string input)
		{
			byte[] bytes = Encoding.Default.GetBytes(input);
			byte[] encodedBytes = MD5.Create().ComputeHash(bytes);
			string str = BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
			return str;
		}

		public static string GetMD5File(string path)
		{
			string str;
			if (File.Exists(path))
			{
				FileStream stream = File.OpenRead(path);
				try
				{
					byte[] encodedBytes = MD5.Create().ComputeHash(stream);
					str = BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
				}
				finally
				{
					if (stream != null)
					{
						((IDisposable)stream).Dispose();
					}
				}
			}
			else
			{
				str = null;
			}
			return str;
		}

		public static void SetCodiceUtenteDefault(string codiceUtente)
		{
			string path = HttpContext.Current.Server.MapPath(WebConfigSettings.UserDataFile);
			if ((string.IsNullOrEmpty(codiceUtente) ? false : File.Exists(path)))
			{
				XDocument document = XDocument.Load(path);
				document.Descendants("codiceUtente").Single<XElement>().Value = codiceUtente;
				document.Save(path);
			}
		}

		public static void UnzipFile(string sourceZipFile, string destFolder)
		{
			(new FastZip()).ExtractZip(sourceZipFile, destFolder, null);
		}

		public static void ZipFile(string sourceFile, string destZipFile)
		{
			string sourceDir = Path.GetDirectoryName(sourceFile);
			string fileFilter = string.Format("{0}$", Path.GetFileName(sourceFile));
			EW.WebModaNet.Code.Utils.ZipFile(destZipFile, sourceDir, false, fileFilter);
		}

		public static void ZipFile(string destZipFile, string sourceFolder, bool recursive, string fileFilter)
		{
			(new FastZip()).CreateZip(destZipFile, sourceFolder, recursive, fileFilter);
		}
	}
}