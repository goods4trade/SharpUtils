using System;
using System.Net.Http;

namespace SharpUtils
{
    public static partial class Extensions
    {
        private const string _httpContext = "MS_HttpContext";
        private const string _remoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(_httpContext))
            {
                dynamic context = request.Properties[_httpContext];
                if (context != null)
                {
                    return context.Request.UserHostAddress;
                }
            }

            if (request.Properties.ContainsKey(_remoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[_remoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            return null;
        }
    }
}
