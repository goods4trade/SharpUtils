using System;
using System.Text.RegularExpressions;

namespace SharpUtil
{
    public static partial class Extensions
    {

        public static bool IsNumeric(this string s)
        {
            string strRegex = RegularExpressions.Validations.NumericRuleRegex;
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.IsMatch(s);
        }

        public static bool IsBlankOrEmpty(this string s)
        {
            return s == null || s.Trim().Length == 0;
        }

        public static bool IsDigit(this string s)
        {
            string strRegex = @"^[\d]*$";
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.IsMatch(s.ToString());
        }

        public static bool IsEmail(this string s)
        {
            Regex re = new Regex(RegularExpressions.Validations.EmailRuleRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return (re.IsMatch(s));
        }

        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public static bool IsValidPhoneUS(this string s)
        {
            Regex re = new Regex(RegularExpressions.Validations.USPhoneRuleRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return (re.IsMatch(s));
        }

        public static bool IsDefaultGuid(this Guid g)
        {
            string s = g.ToString(),
                   strRegex = @"^[0-]*$";
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.IsMatch(s);
        }

    }
}
