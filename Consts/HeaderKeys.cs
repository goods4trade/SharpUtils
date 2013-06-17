using System;

namespace SharpUtils.Consts
{
    public class HeaderKeys
    {
        public const string SCHEME = "Basic";
        public const string AuthSCHEME = "OAuth";
        public const string ApiUserKeyName = "X-Api-App-Key";
        public const string ApiAuthorizedKeyName = "X-Api-Access-Token";
        public const string ApiAuthorizedKeyStatusName = "X-Api-Auth-Key-Status";
        public const string ApiRoutePermissionName = "X-Api-Route-Permission";
        public const string ApiAccessName = "X-Api-Access";
        public const string ForwardedForName = "X-Forwarded-For";
        public const string ForwardedForApiName = "X-Forwarded-For-Api";
    }
}
