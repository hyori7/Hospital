using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace BusinessTier
{
	public class Cryptograph
	{
		//default password
		private static string password = "Tedspassword";

		public static String Passowrd
		{
			set
			{
				password = value;
			}
		}

		//encrypt text
		public static string Encrypt(string text)
		{
			return Crypt(text, password, true);
		}

		//decrupt text
		public static string Decrypt(String text)
		{
			return Crypt(text, password, false);
		}

		//encrypt and decrypt text using a specfic password
		public static string Crypt(string text, string password, bool b_Encrypt)
		{
			byte[] utf8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };

			PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(password, utf8_Salt);

			Rijndael i_Alg = Rijndael.Create();
			i_Alg.Key = i_Pass.GetBytes(32);
			i_Alg.IV = i_Pass.GetBytes(16);

			ICryptoTransform i_Trans = (b_Encrypt) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();

			MemoryStream i_Mem = new MemoryStream();
			CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write);

			byte[] utf8_Data;
			if (b_Encrypt) utf8_Data = Encoding.Unicode.GetBytes(text);
			else utf8_Data = Convert.FromBase64String(text);

			try
			{
				i_Crypt.Write(utf8_Data, 0, utf8_Data.Length);
				i_Crypt.Close();
			}
			catch { return null; }

			if (b_Encrypt) return Convert.ToBase64String(i_Mem.ToArray());
			else return Encoding.Unicode.GetString(i_Mem.ToArray());
		}
	}
}
