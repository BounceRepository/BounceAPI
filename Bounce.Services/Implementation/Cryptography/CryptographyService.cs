using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO.Hash;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Cryptography
{
	public class CryptographyService : ICryptographyService
	{
		private readonly BounceDbContext _context;
        public CryptographyService(BounceDbContext context)
        {
            _context = context;
        }
        private readonly int _hashSize = 32;
		private readonly int _hashIterations = 128;
		internal static readonly char[] Chars =
			"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

		private const string BVN_SECRET_KEY = "iNivDmHLpUA223sqsfhqGbMRdRj1PVk";

		public string Base64Decode(string base64EncodedData)
		{
			var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
			
		}

		public string Base64Encode(string plainText)
		{
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(plainTextBytes);
		}

		public string ComputeHmac256(string key, string model)
		{
			var encoding = new ASCIIEncoding();
			byte[] keyBytes = encoding.GetBytes(key);
			byte[] modelBytes = encoding.GetBytes(model);

			var hmacsha256 = new HMACSHA256(key: keyBytes);
			byte[] hmacbBytesMessage = hmacsha256.ComputeHash(modelBytes);
			using (hmacsha256)
			{
				return ByteToHex(hmacbBytesMessage);
				// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
				// String.Concat(Array.ConvertAll(hmacbBytesMessage, x => x.ToString("x2")));
				// return Convert.ToBase64String((hmacbBytesMessage));
			}
		}

		private string ByteToHex(byte[] hmacbBytesMessage)
		{
			char[] c = new char[hmacbBytesMessage.Length * 2];

			byte b;

			for (int bx = 0, cx = 0; bx < hmacbBytesMessage.Length; ++bx, ++cx)
			{
				b = ((byte)(hmacbBytesMessage[bx] >> 4));
				c[cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

				b = ((byte)(hmacbBytesMessage[bx] & 0x0F));
				c[++cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
			}

			return new string(c);
		}

		public string CreateClientEncryptionKey()
		{
			throw new NotImplementedException();
		}

		public string DecryptApiKey(string clientId, string encryptKey)
		{
			string decryptedValue = null;
			encryptKey = encryptKey.Replace(" ", "+");
			byte[] cipherBytes = Convert.FromBase64String(encryptKey);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(clientId,
					new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				if (encryptor != null)
				{
					encryptor.Key = pdb.GetBytes(32);
					encryptor.IV = pdb.GetBytes(16);
					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
							CryptoStreamMode.Write))
						{
							cs.Write(cipherBytes, 0, cipherBytes.Length);
							cs.Close();
						}

						decryptedValue = Encoding.UTF8.GetString(ms.ToArray());
					}
				}
			}

			return decryptedValue;
		}

		public string DecryptBvn(string encryptBvn)
		{
			string decryptedValue = null;
			// var key = Encoding.UTF8.(BvnSecretKey);
			byte[] cipherBytes = Convert.FromBase64String(encryptBvn);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(BVN_SECRET_KEY,
					new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				if (encryptor != null)
				{
					encryptor.Key = pdb.GetBytes(32);
					encryptor.IV = pdb.GetBytes(16);
					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
							CryptoStreamMode.Write))
						{
							cs.Write(cipherBytes, 0, cipherBytes.Length);
							cs.Close();
						}

						decryptedValue = Encoding.UTF8.GetString(ms.ToArray());
					}
				}
			}

			return decryptedValue;
		}

		public ClientApiKey EncryptApiKey(string clientId, string keyPrefix)
		{
			ClientApiKey clientApiKey = null;
			var apiKey = GenerateClientKey(20, keyPrefix);
			var clearBytes = Encoding.UTF8.GetBytes(apiKey);

			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(clientId,
					new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				if (encryptor != null)
				{
					encryptor.Key = pdb.GetBytes(32);
					encryptor.IV = pdb.GetBytes(16);
					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
							CryptoStreamMode.Write))
						{
							cs.Write(clearBytes, 0, clearBytes.Length);
							cs.Close();
						}


						clientApiKey = new ClientApiKey
						{ EncryptApiKey = Convert.ToBase64String(ms.ToArray()), ApiKey = apiKey };
					}
				}
			}

			return clientApiKey;
		}

		public string EncryptBvn(string bvn)
		{
			var clearBytes = Encoding.UTF8.GetBytes(bvn);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(BVN_SECRET_KEY,
					new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				if (encryptor != null)
				{
					encryptor.Key = pdb.GetBytes(32);
					encryptor.IV = pdb.GetBytes(16);
					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
							CryptoStreamMode.Write))
						{
							cs.Write(clearBytes, 0, clearBytes.Length);
							cs.Close();
						}

						return Convert.ToBase64String(ms.ToArray());
					}
				}
			}

			return "";
		}

		public string FlutterWaveDecryptData(string encryptedData, string encryptionKey)
		{
			throw new NotImplementedException();
		}

		public string FlutterWaveEncryptData(string encryptionKey, string model)
		{
			throw new NotImplementedException();
		}

		public HashDetail GenerateHash(string input)
		{
			if (string.IsNullOrEmpty(input))
				return null;
			byte[] salt = CreateSalt();
			byte[] hash = CreateHash(input, salt);

			return new HashDetail { Salt = Convert.ToBase64String(salt), HashedValue = Convert.ToBase64String(hash) };

		}

		public string GetFlutterwaveEcryptionKey(string secretKey)
		{
			throw new NotImplementedException();
		}

		public bool ValidateHash(string input, string salt, string hashedValue)
		{
			if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(salt) || string.IsNullOrEmpty(hashedValue))
				return false;
			byte[] saltByte = Convert.FromBase64String(salt);
			byte[] inputHash = CreateHash(input, saltByte);
			string hashedString = Convert.ToBase64String(inputHash);

			if (hashedString.Equals(hashedValue))
				return true;

			return false;
		}

		private byte[] CreateSalt()
		{
			byte[] salt;
			using (RNGCryptoServiceProvider rNgCryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				rNgCryptoServiceProvider.GetBytes(salt = new byte[_hashSize]);
			}

			return salt;
		}

		private byte[] CreateHash(string input, byte[] salt)
		{
			byte[] hash;
			using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(input, salt, _hashIterations))
			{
				hash = hashGenerator.GetBytes(_hashSize);
			}

			return hash;
		}
		private string GenerateClientKey(int size, string keyPrefix)
		{
			byte[] data = new byte[4 * size];
			using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
			{
				crypto.GetBytes(data);
			}

			StringBuilder result = new StringBuilder(size);
			for (int i = 0; i < size; i++)
			{
				var rnd = BitConverter.ToUInt32(data, i * 4);
				var idx = rnd % Chars.Length;

				result.Append(Chars[idx]);
			}

			return string.Concat(keyPrefix, result.ToString());
		}

        public async Task<string> GenerateValidationTokenAsync(string email = "NA", string phone = "FA")
        {
			var tokens = _context.Tokens.Where(x => x.UserEmail == email);
			if(tokens.Any())
            {
				_context.RemoveRange(tokens);
				await _context.SaveChangesAsync();
			}
	

			var token = new Random().Next(0, 10000).ToString("D4");
			var tokenModel = new TokenModel
			{
				Token = token,
				UserEmail = email,
				PhoneNumber = phone,
				DateCreated = DateTime.Now,
				LastModifiedBy = DateTime.Now.ToString()

			};
			await _context.AddAsync(tokenModel);
			var saveStatus = await _context.SaveChangesAsync() > 0;
			if (saveStatus)
				return token;

			return String.Empty;
		
		}

	
		public async Task<string> GeneratePatientIdAsync ( string prrfix = "BNP")
        {
			var serialNumber = _context.SerialNumbers.FirstOrDefault();
			if(serialNumber == null)
            {
				var model = new SerialNumber
				{
					LastModifiedBy = DateTime.Now.ToString(),
					DateCreated = DateTime.Now,
					ConsultationCount = 0,
					AdminCount = 0,
					PatientCount = 0,
					TherapistCount = 0,
				};
				await _context.AddAsync(model);
				await _context.SaveChangesAsync();

			
				return $"{prrfix}{1.ToString("D4")}";
            }
			long index = default;
			if(prrfix == "BNP")
            {
				index = serialNumber.PatientCount++;
				serialNumber.PatientCount =+ 1;
			}
            else
            {
				index = serialNumber.TherapistCount++;
				serialNumber.PatientCount = index;
			}
			
			 _context.Update(serialNumber);
			await _context.SaveChangesAsync();

			return $"{prrfix}{index.ToString("D4")}";
		}
		public async Task<Response> ValidateTokenAsync(string token)
        {
			var userToken = _context.Tokens.FirstOrDefault(x => x.Token.Contains(token));
			if(userToken == null)
				return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "Invalid token" };

			if ((DateTime.Now - userToken.DateCreated).TotalMinutes > 5)
            {
				_context.Tokens.Remove(userToken);
				await _context.SaveChangesAsync();
				return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "Token has expired" };
			}
				
			_context.Tokens.Remove(userToken);
			await _context.SaveChangesAsync();
			return new Response { StatusCode = StatusCodes.Status200OK, Message = "Token token has been validated" , Data = new { userEmail = userToken.UserEmail } };

		}

	}
}
