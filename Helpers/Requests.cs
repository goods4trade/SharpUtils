using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.UI;

namespace MAXX.Utils.Helpers
{
    public class Requests
    {
        static string _forwardedForApiIP = string.Empty;
        static string _apiRoutePermission = string.Empty;
        static string _apiAuthorizedKey = string.Empty;
        static string _apiUserKey = string.Empty;
        static string _apiAccess = string.Empty;

        public static string RootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.ServerVariables["http_host"];
        public static string QueryString = HttpContext.Current.Request.Url.Query.ToString();
        public static string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        public static string CurrentRootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + VirtualPathUtility.ToAbsolute("~/");
        public static string CurrentUrlWithNoQueryString = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
        public static string ClientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        public static string ForwardedIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                
        public static string ForwardedForApiIP
        {
            get
            {
                if (string.IsNullOrEmpty(_forwardedForApiIP) && HttpContext.Current.Request.Headers.AllKeys.Contains(Consts.HeaderKeys.ForwardedForApiName))
                {
                    _forwardedForApiIP = HttpContext.Current.Request.Headers.GetValues(Consts.HeaderKeys.ForwardedForApiName).SingleOrDefault();
                }

                return string.IsNullOrEmpty(_forwardedForApiIP) ? ClientIP : _forwardedForApiIP;
            }
        }

        public static string IP 
        {
            get
            {
                // get real ip address (if user behind proxy server)
                string ip = ForwardedIP;

                // get the client ip if there are multiple ips present in HTTP_X_FORWARDED_FOR. 
                // The general format of the field is:
                // X-Forwarded-For: client, proxy1, proxy2
                ip = string.IsNullOrEmpty(ip) ? ip : ip.Split(',').First().Trim();

                if (string.IsNullOrEmpty(ip))
                {
                    ip = ClientIP;
                }

                return ip;
            }        
        }

        public static string ApiRoutePermission
        {
            get
            {
                if (string.IsNullOrEmpty(_apiRoutePermission) && HttpContext.Current.Request.Headers.AllKeys.Contains(Consts.HeaderKeys.ApiRoutePermissionName))
                {
                    _apiRoutePermission = HttpContext.Current.Request.Headers.GetValues(Consts.HeaderKeys.ApiRoutePermissionName).SingleOrDefault();
                }
                return _apiRoutePermission;
            }
        }

        public static string ApiAuthorizedKey
        {
            get
            {
                if (string.IsNullOrEmpty(_apiAuthorizedKey) && HttpContext.Current.Request.Headers.AllKeys.Contains(Consts.HeaderKeys.ApiAuthorizedKeyName))
                {
                    _apiAuthorizedKey = HttpContext.Current.Request.Headers.GetValues(Consts.HeaderKeys.ApiAuthorizedKeyName).SingleOrDefault();
                }
                return _apiAuthorizedKey;
            }
        }

        public static string ApiUserKey
        {
            get
            {
                if (string.IsNullOrEmpty(_apiUserKey) && HttpContext.Current.Request.Headers.AllKeys.Contains(Consts.HeaderKeys.ApiUserKeyName))
                {
                    _apiUserKey = HttpContext.Current.Request.Headers.GetValues(Consts.HeaderKeys.ApiUserKeyName).SingleOrDefault();
                }
                return _apiUserKey;
            }
        }

<<<<<<< HEAD












































        private static string FinalizeValues(string val, string defaultVal, Enums.DataType dt)
        {
            switch (dt)
            {
                case Enums.DataType.Bool:
                    //val = !val.Trim().ListFindNoCase("true,false") ? "false" : val;
                    break;
                case Enums.DataType.Int:
                    val = !defaultVal.Trim().IsNumeric() ? "0" : val;
                    break;
                case Enums.DataType.Char:
                    val = defaultVal.Length > 1 ? defaultVal.Left(0) : val;
                    break;
                default:
                    break;
            }
            return val;
        }

        #region get form request

        public static string GetForm(string form, string defaultVal, Enums.DataType dt)
        {
            string val;

            switch (dt)
            {
                case Enums.DataType.Bool:
                    val = (HttpContext.Current.Request.Form[form] ?? (!defaultVal.Trim().ListFindNoCase("true,false") ? "false" : defaultVal)).ToString();
                    break;
                case Enums.DataType.Int:
                    val = (HttpContext.Current.Request.Form[form] ?? (!defaultVal.Trim().IsNumeric() ? "0" : defaultVal)).ToString();
                    break;
                case Enums.DataType.Char:
                    val = (HttpContext.Current.Request.Form[form] ?? (defaultVal.Length > 1 ? defaultVal.Left(0) : defaultVal)).ToString();
                    break;
                default:
                    val = (HttpContext.Current.Request.Form[form] ?? defaultVal).ToString();
                    break;
            }

            return FinalizeValues(val, defaultVal, dt);
        }

        public static string GetForm(string form, Enums.DataType dt)
        {
            string defaultVal = "";
            return GetForm(form, defaultVal, dt);
        }

        public static string GetForm(string form, string defaultVal)
        {
            return GetForm(form, defaultVal, Enums.DataType.String);
        }

        public static string GetForm(string form)
        {
            return GetForm(form, "");
        }

        #endregion get form

        #region get query string

        public static string GetQueryString(string queryString, string defaultVal, Enums.DataType dt)
        {
            string val;

            switch (dt)
            {
                case Enums.DataType.Bool:
                    val = (HttpContext.Current.Request.QueryString[queryString] ?? (!defaultVal.Trim().ListFindNoCase("true,false") ? "false" : defaultVal)).ToString();
                    break;
                case Enums.DataType.Int:
                    val = (HttpContext.Current.Request.QueryString[queryString] ?? (!defaultVal.Trim().IsNumeric() ? "0" : defaultVal)).ToString();
                    break;
                case Enums.DataType.Char:
                    val = (HttpContext.Current.Request.QueryString[queryString] ?? (defaultVal.Length > 1 ? defaultVal.Left(0) : defaultVal)).ToString();
                    break;
                default:
                    val = (HttpContext.Current.Request.QueryString[queryString] ?? defaultVal).ToString();
                    break;
            }

            return FinalizeValues(val, defaultVal, dt);
        }

        public static string GetQueryString(string queryString, Enums.DataType dt)
        {
            string defaultVal = "";
            return GetQueryString(queryString, defaultVal, dt);
        }

        public static string GetQueryString(string queryString, string defaultVal)
        {
            return GetQueryString(queryString, defaultVal, Enums.DataType.String);
        }

        public static string GetQueryString(string queryString)
        {
            return GetQueryString(queryString, "");
        }

        #endregion get query string

        #region get param

        public static string GetParam(string param, string defaultVal, Enums.DataType dt)
        {
            string val;

            switch (dt)
            {
                case Enums.DataType.Bool:
                    val = (HttpContext.Current.Request.Params[param] ?? (!defaultVal.Trim().ListFindNoCase("true,false") ? "false" : defaultVal)).ToString();
                    break;
                case Enums.DataType.Int:
                    val = (HttpContext.Current.Request.Params[param] ?? (!defaultVal.Trim().IsNumeric() ? "0" : defaultVal)).ToString();
                    break;
                case Enums.DataType.Char:
                    val = (HttpContext.Current.Request.Params[param] ?? (defaultVal.Length > 1 ? defaultVal.Left(0) : defaultVal)).ToString();
                    break;
                default:
                    val = (HttpContext.Current.Request.Params[param] ?? defaultVal).ToString();
                    break;
            }

            return FinalizeValues(val, defaultVal, dt);
        }

        public static string GetParam(string param, Enums.DataType dt)
        {
            string defaultVal = "";
            return GetParam(param, defaultVal, dt);
        }

        public static string GetParam(string param, string defaultVal)
        {
            return GetParam(param, defaultVal, Enums.DataType.String);
        }

        public static string GetParam(string param)
        {
            return GetParam(param, "");
        }

        #endregion get param

        #region get route data

        public static string GetRouteData(string routeParam, string defaultVal, Enums.DataType dt)
        {
            Page page = new Page();
            string val = (page.RouteData.Values[routeParam] ?? GetQueryString(routeParam, defaultVal, dt)).ToString();

            switch (dt)
            {
                case Enums.DataType.Bool:
                    val = !val.Trim().ListFindNoCase("true,false") ? "false" : val;
                    break;
                case Enums.DataType.Int:
                    val = !defaultVal.Trim().IsNumeric() ? "0" : val;
                    break;
                case Enums.DataType.Char:
                    val = defaultVal.Length > 1 ? defaultVal.Left(0) : val;
                    break;
                default:
                    break;
            }

            return FinalizeValues(val, defaultVal, dt);
        }

        public static string GetRouteData(string routeParam, Enums.DataType dt)
        {
            string defaultVal = "";
            return GetRouteData(routeParam, defaultVal, dt);
        }

        public static string GetRouteData(string routeParam, string defaultVal)
        {
            return GetRouteData(routeParam, defaultVal, Enums.DataType.String);
        }

        public static string GetRouteData(string routeParam)
        {
            return GetRouteData(routeParam, "");
        }

        #endregion get route data

=======
        public static bool ApiAccess
        {
            get
            {
                if (string.IsNullOrEmpty(_apiAccess) && HttpContext.Current.Request.Headers.AllKeys.Contains(Consts.HeaderKeys.ApiAccessName))
                {
                    _apiAccess = HttpContext.Current.Request.Headers.GetValues(Consts.HeaderKeys.ApiAccessName).SingleOrDefault();
                }
                return Convert.ToBoolean(string.IsNullOrEmpty(_apiAccess) ? "false" : _apiAccess);
            }
        }
>>>>>>> f361537f27e6b6f61d375995c8601980250ac55a
    }
}
