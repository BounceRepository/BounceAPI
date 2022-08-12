using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Utilies
{
    public class EmailFormatter
    {
        public static string MailPath = "Templates";
        public static string ConfirmationEmail = "EmailConfirmation.html"; 

        public static string FormatEmaiConfimation(string url, string rootPath)
        {
            string templateRootPath = CombinePath(rootPath,ConfirmationEmail);
            string content = string.Empty;
            using var sr = new StreamReader(templateRootPath);
            content = sr.ReadToEnd();
            content = content.Replace("{{Url}}", url);
            return content;
        }

        private static string CombinePath(string rootpath, string name)
        {
            return Path.Combine(rootpath,MailPath,name);
        }
    }
}
