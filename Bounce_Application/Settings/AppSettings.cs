using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Settings
{
    public class AppSettings
    {
        public string EncryprionKey { get; set; }
        public string EncryprionIV { get; set; }
        public string BVN_SECRET_KEY { get; set; }
        public string Chars { get; set; }
        public int HashSize { get; set; }
        public int HashIterations { get; set; }
    }
}
