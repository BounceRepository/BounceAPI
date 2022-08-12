using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.DTO.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Cryptography.Hash
{
	public interface ICryptographyService
	{
        HashDetail GenerateHash(string input);
        bool ValidateHash(string input, string salt, string hashedValue);
        string Base64Encode(string plainText);
        string Base64Decode(string base64EncodedData);
        #region FlutterWave encryption
        string GetFlutterwaveEcryptionKey(string secretKey);
        string FlutterWaveEncryptData(string encryptionKey, string model);
        string FlutterWaveDecryptData(string encryptedData, string encryptionKey);
        Task<string> GenerateValidationTokenAsync(string email = "NA", string phone = "FA");

        Task<Response> ValidateTokenAsync(string token);

        #endregion

        #region Generate Client Key
        ClientApiKey EncryptApiKey(string clientId, string keyPrefix);
        string EncryptBvn(string bvn);
        string DecryptBvn(string encryptBvn);
        string DecryptApiKey(string clientId, string encryptKey);
        string ComputeHmac256(string key, string model);
     

        #endregion

        string CreateClientEncryptionKey();
    }
}
