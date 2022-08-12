using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Auth.Response
{
    public class TokenViewModel
    {
        [JsonProperty("auth_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("id")]
        [JsonIgnore]
        public string UserId { get; set; }

        [JsonProperty("accountid")]
        [JsonIgnore]
        public string UserAccountId { get; set; }

        [JsonProperty("user_name")]
        [JsonIgnore]
        public string UserName { get; set; }
    }
}
