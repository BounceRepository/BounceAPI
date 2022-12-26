using System;
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



		public static DateTimeOffset ConvertToHour(this string startTime, DateTimeOffset dateTime)
		{
			if (string.IsNullOrEmpty(startTime))
				throw new ArgumentNullException("string can not be null");

            try
            {
				
				var timeInt = int.Parse(startTime.Split(':')[0]);
				var timeUTC = startTime.Split(' ').LastOrDefault().ToLower();
				if (timeUTC == "pm" && timeInt != 12 )
				{
					timeInt = 12 + timeInt;
				}

				return dateTime.Date.AddHours(timeInt);
			}
			catch(Exception ex)
            {
				throw new ArgumentNullException("string can not be null");
			};
		}

		public static DateTime ConvertToHourLocal(this string startTime, DateTime dateTime)
		{
			if (string.IsNullOrEmpty(startTime))
				throw new ArgumentNullException("string can not be null");

			try
			{

				var timeInt = int.Parse(startTime.Split(':')[0]);
				var timeUTC = startTime.Split(' ').LastOrDefault().ToLower();
				if (timeUTC == "pm" && timeInt != 12)
				{
					timeInt = 12 + timeInt;
				}

				return dateTime.Date.AddHours(timeInt);
			}
			catch (Exception ex)
			{
				throw new ArgumentNullException("string can not be null");
			};
		}

		public static bool ValidTime2(this string startTime)
		{
			if (string.IsNullOrEmpty(startTime))
				throw new ArgumentNullException("string can not be null");

			try
			{
				var timeInt = int.Parse(startTime.Split(':')[0]);
				var timeUTC = startTime.Split(' ').LastOrDefault().ToLower();
				if (timeUTC == "pm" && timeInt != 12)
				{
					timeInt = 12 + timeInt;
				}
				var time = DateTime.Now.Date.AddHours(timeInt);
				if (time.Hour > DateTime.Now.Hour - 1)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				throw new ArgumentNullException("string can not be null");
			};
		}

		public static string GetEndDate(DateTimeOffset statrtTme)
        {
			var time3 = statrtTme.ToString("hh:00 t");
			var decodeMessage2 = Uri.UnescapeDataString(time3);
			if (decodeMessage2.Contains("A"))
				decodeMessage2 = decodeMessage2.Replace("A", "AM");

			if (decodeMessage2.Contains("P"))
				decodeMessage2 = decodeMessage2.Replace("P", "PM");

			return decodeMessage2;
		}
		public static bool ValidTime(this string startTime)
		{
			if (string.IsNullOrEmpty(startTime))
				throw new ArgumentNullException("string can not be null");

			try
			{
				var decr1 = startTime.Split(':');		
				var decr2 = decr1[1].Split(' ');
				var decr = startTime.Split(':')[0];
				var timeInt = int.Parse(decr.Split(':')[0]);
				var timeUTC = decr2[1].ToLower();
				if (timeUTC == "pm" && timeInt != 12)
				{
					timeInt = 12 + timeInt;
				}

				var time =  DateTime.Now.Date.AddHours(timeInt);
				if (time.Hour > DateTime.Now.Hour - 1)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				throw new ArgumentNullException("string can not be null");
			};
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
