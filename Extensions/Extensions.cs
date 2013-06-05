using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SharpUtils
{
    public static partial class Extensions
    {
        public static bool TryConvertToEnum<T>(int value, out T result)
        {
            result = default(T);
            bool success = Enum.IsDefined(typeof(T), value);
            if (success)
            {
                result = (T)Enum.ToObject(typeof(T), value);
            }
            return success;
        }

        public static Guid ParseGuid(this string s)
        {
            Guid guid;
            Guid.TryParse(s, out guid);

            return guid;
        }

        public static string ToNumberic(this string s)
        {
            string strRegex = @"[^0-9]";
            s = (s ?? "");
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Replace(s, "");
        }

        public static string ToAlpha(this string s)
        {
            string strRegex = @"[^A-Za-z]";
            s = (s ?? "");
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Replace(s, "");
        }

        public static string ToAlphaNumeric(this string s)
        {
            string strRegex = @"[^A-Za-z0-9]";
            s = (s ?? "");
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Replace(s, "");
        }

        public static string ToUrlSlug(this string s)
        {
            return s.ReplaceAllSpecialCharacters("-").ReplaceAllRepeatedCharacters('-', "-").ReplaceAllRepeatedCharacters('_', "_").Trim('-').Trim('_').ToLower();
        }
        
        //exp: "CACIIsAnITCompany" converting to "C A C I Is An I T Company"
        public static string SeparateCamelCase(this string s)
        {
            return Regex.Replace(s, "([A-Z])", " $1").Trim();
        }

        //exp: "CACIIsAnITCompany" converting to "CACI Is An IT Company"
        public static string SeparateCammelCaseToWords(this string s)
        {
            return Regex.Replace(Regex.Replace(s, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        public static string ConvertStringToStandardVariableName(this string s)
        {
            string replaceString = "_",
                   strRegex = @"[^A-Za-z0-9_]";

            s = (s ?? "");
            Regex regex = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Replace(s, replaceString).ReplaceAllRepeatedCharacters('_', "_");
        }

        public static string Left(this string s, int count)
        {
            return s.Substring(0, count);
        }

        public static string Right(this string s, int count)
        {
            if (count > s.Length)
                return s;
            return s.Substring(s.Length - count, count);
        }

        public static int GetUrlSlugId(this string s, char delimiter)
        {
            string[] aSlug;
            int slugId;
            bool isInt;

            s = s.ToUrlSlug();
            aSlug = s.Split(delimiter);
            isInt = int.TryParse(aSlug[aSlug.Length - 1], out slugId);
            slugId = !isInt ? 0 : slugId;

            return slugId;
        }
        
        public static bool ListFindNoCase(this string valueList, string value)
        {
            return valueList.ListFindNoCase(value, ",");
        }

        public static bool ListFindNoCase(this string valueList, string value, string delimiter)
        {
            string strRegex = @"(^|" + delimiter + ")(" + value + ")(" + delimiter + "|$)";
            Regex re = new Regex(strRegex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return (re.IsMatch(valueList));
        }

        public static string ListAppend(this string valueList, string appendValue)
        {
            return valueList.ListAppend(appendValue, ",");
        }

        public static string ListAppend(this string valueList, string appendValue, string delimiter)
        {
            return valueList.Trim() == "" ? appendValue : valueList + delimiter + appendValue;
        }

        public static string GetLeftStringAtFirstIndex(this string s, string indexOf)
        {
            return s.IndexOf(indexOf) != -1 ? s.Substring(0, s.IndexOf(indexOf)) : s;
        }

        public static string[] ListToArray(this string s, string Delimiter)
        {
            string sNew = s.Trim();
            ArrayList newArr = new ArrayList();
            do
            {
                newArr.Add(sNew.GetLeftStringAtFirstIndex(Delimiter).Trim());
                if (sNew.IndexOf(Delimiter) != -1)
                {
                    sNew = sNew.Remove(0, sNew.IndexOf(Delimiter) + Delimiter.Length);
                }
            } while (sNew.IndexOf(Delimiter) != -1);

            return (string[])newArr.ToArray(typeof(string));
        }
        
        private static Int64 ParsingRouteId(string s, char del)
        {
            string idString = "0";
            string[] idArr;

            Int64 id = 0;
            if (s != null)
            {
                idArr = s.Split(del);
                idString = idArr.Length > 1 ? idArr[idArr.Length - 1] : idString;
                id = idString.IsDigit() ? Convert.ToInt64(idString) : 0;
            }

            return id;
        }

        public static Int64 ParseRouteId(this string s, char del)
        {
            return ParsingRouteId(s, del);
        }

        public static Int64 ParseRouteId(this string s)
        {
            char del = '_';
            return ParsingRouteId(s, del);
        }

        public static HttpStatusCode ResponseStatusCode<T>(this T o)
        {
            return o == null ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        }

        public static HttpStatusCode ResponseStatusCode<T>(this List<T> o)
        {
            return o == null || o.Count == 0 ? HttpStatusCode.NoContent : HttpStatusCode.OK;
        }
        
    }
}
