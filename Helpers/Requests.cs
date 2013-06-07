using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace SharpUtils.Helpers
{
    public class Requests
    {
        static string _forwardedForApiIP = string.Empty;
        static string _apiRoutePermission = string.Empty;
        static string _apiAuthorizedKey = string.Empty;
        static string _apiUserKey = string.Empty;

        public static string RootUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.ServerVariables["http_host"];
        public static string QueryString = HttpContext.Current.Request.Url.Query.ToString();
        public static string CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
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

    }
}
