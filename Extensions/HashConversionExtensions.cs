using System;
using System.Linq;
using System.Text;

namespace SharpUtil
{
    public static partial class Extensions
    {
        public static string ToMD5Hash(this byte[] bytes)
        {
            return IdKeyGenerator.MD5Hash(bytes);
        }

        public static string ToMD5Hash(this string s)
        {
            return Encoding.UTF8.GetBytes(s).ToMD5Hash();
        }

        public static string ToRfc2898Hash(this string s, string salt)
        {
            return IdKeyGenerator.CreateRfc2898Salt(s, salt);
        }

        public static string Byte2String(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            bytes.ToList().ForEach(b => sb.AppendFormat("{0:x2}", b));
            return sb.ToString();
        }

        public static string ToShortGuidString(this Guid g)
        {
            return IdKeyGenerator.StringHash(g.ToString());
        }

        public static string FromBase64String(this string s)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            return encoding.GetString(Convert.FromBase64String(s));
        }

        public static string ToBase64String(this string s)
        {
            byte[] b = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(b);
        }
    }
}
