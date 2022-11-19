using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
