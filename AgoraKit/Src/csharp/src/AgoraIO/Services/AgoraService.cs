using AgoraIO.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgoraIO.Services
{
    public  class AgoraService
    {
       

        public string appId { get; set; }
        public string appCertificate { get; set; }
        public string channelName { get; set; }
        public string uid { get; set; }
        public string userAccount { get; set; }
        public int expirationTimeInSeconds { get; set; }


        public AgoraService(string appId, string appCertificate, string channelName, string uid, string userAccount, int expirationTimeInSeconds)
        {
            this.appId = $"<{appId}>" ;
            this.appCertificate = $"<{appCertificate}>";
            this.channelName = $"<{channelName}>"; ;
            this.uid = uid;
            this.userAccount = userAccount;
            this.expirationTimeInSeconds = expirationTimeInSeconds;
        }

        public string GenerateDynamicKey()
        {
            AccessToken token = new AccessToken(appId, appCertificate, channelName, uid);
            string token2 = SignalingToken.getToken(appId, appCertificate, userAccount, expirationTimeInSeconds);
            // Specify a privilege level and expire time for the token
            token.addPrivilege(Privileges.kJoinChannel, Convert.ToUInt32(expirationTimeInSeconds));
            return  token.build();
 
        }

        //private string appId = "<Your app Id>";
        //private string appCertificate = "<Your app aertificate>";
        //private string channelName = "<Your channel name>";
        //private string uid = "0";
        //private string userAccount = "User account";
        //private int expirationTimeInSeconds = 3600; /
       
    }
}
