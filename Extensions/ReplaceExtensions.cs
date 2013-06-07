using System;
using System.Text.RegularExpressions;

namespace SharpUtils
{
    public static partial class Extensions
    {
        public static string ReplaceAllSpecialCharacters(this string s, string replaceString)
        {
            string strRegex = @"[^A-Za-z0-9_-]";
            s = (s ?? "");
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Replace(s, replaceString);
        }

        public static string ReplaceAllRepeatedCharacters(this string s, char repeatChar, string replaceString)
        {
            string strRegex = "[" + repeatChar.ToString() + "]{2,}";

            s = (s ?? "");
            replaceString = (replaceString ?? "");
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Replace(s, replaceString);
        }

        public static string HTMLStrip(this string s)
        {
            return s.HTMLStrip(string.Empty);
        }

        public static string HTMLStrip(this string s, string replaceString)
        {
            string RegxPattern = "(<([^>]+)>)";
            return Regex.Replace(s, RegxPattern, replaceString, RegexOptions.IgnoreCase);
        }

        // change the first letter to upper case
        // ex: "this is good!" to "This is good"
        public static string FirstLetterUpper(this string s)
        {
            return Regex.Replace(s, @"^\W*\w", new MatchEvaluator(match => match.Value.ToUpper()));
        }
    }
}
