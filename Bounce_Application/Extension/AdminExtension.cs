﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public  static class StringExtension
    {
        public static string[] ToSplit(this string value, char seperator)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.Split(seperator);
        }







		#region encryption
		public static string BinaryToString(string binary)
		{
			if (string.IsNullOrEmpty(binary))
				throw new ArgumentNullException("binary");

			if ((binary.Length % 8) != 0)
				throw new ArgumentException("Binary string invalid (must divide by 8)", "binary");

			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < binary.Length; i += 8)
			{
				string section = binary.Substring(i, 8);
				int ascii = 0;
				try
				{
					ascii = Convert.ToInt32(section, 2);
				}
				catch
				{
					throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
				}
				builder.Append((char)ascii);
			}
			return builder.ToString();				

		}



		public static string EncryptString( this string  val)
		{
			MemoryStream ms = new MemoryStream();

			try
			{

				string sharedkeyval = "000000010000001000000101000001010000011100001011010011010001000100010010000100010000110100001011000001110000001000000100000010000000000100001100000000110000010100000111000010110000110101011011";
				string sharedvectorval = "0000000100000010000000110000010100000111000010110000110100010000";

				sharedvectorval = BinaryToString(sharedvectorval);
				sharedkeyval = BinaryToString(sharedkeyval);

	
				byte[] sharedkey = System.Text.Encoding.GetEncoding("utf-8").GetBytes(sharedkeyval);
				byte[] sharedvector = System.Text.Encoding.GetEncoding("utf-8").GetBytes(sharedvectorval);

				TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
				byte[] toEncrypt = Encoding.UTF8.GetBytes(val);

				CryptoStream cs = new CryptoStream(ms, tdes.CreateEncryptor(sharedkey, sharedvector), CryptoStreamMode.Write);
				cs.Write(toEncrypt, 0, toEncrypt.Length);
				cs.FlushFinalBlock();

			}
			catch
			{
				return "";
			}
			return Convert.ToBase64String(ms.ToArray());
		}
		public static string DecryptString(this string val)
		{
			MemoryStream ms = new MemoryStream();

			try
			{
				string sharedkeyval = "000000010000001000000101000001010000011100001011010011010001000100010010000100010000110100001011000001110000001000000100000010000000000100001100000000110000010100000111000010110000110101011011";
				string sharedvectorval = "0000000100000010000000110000010100000111000010110000110100010000";


				sharedkeyval = BinaryToString(sharedkeyval);
				sharedvectorval = BinaryToString(sharedvectorval);

				byte[] sharedkey = System.Text.Encoding.GetEncoding("utf-8").GetBytes(sharedkeyval);
				byte[] sharedvector = System.Text.Encoding.GetEncoding("utf-8").GetBytes(sharedvectorval);

				TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
				byte[] toDecrypt = Convert.FromBase64String(val);

				CryptoStream cs = new CryptoStream(ms, tdes.CreateDecryptor(sharedkey, sharedvector), CryptoStreamMode.Write);


				cs.Write(toDecrypt, 0, toDecrypt.Length);
				cs.FlushFinalBlock();
			}
			catch
			{
				return "";
			}
			return Encoding.UTF8.GetString(ms.ToArray());
		}

		#endregion
	}
}
