using System;
using System.Net;
using SharpUtils.BaseObjects;

namespace SharpUtils.Helpers
{
    public class Responses
    {
        public static HttpStatusMessage HttpStatusException(HttpStatusCode statusCode, string messageDetail)
        {
            return new HttpStatusMessage { Status = Convert.ToInt16(statusCode), Message = Convert.ToInt16(statusCode).ToString() + " " + statusCode.ToString().SeparateCammelCaseToWords(), MessageDetail = messageDetail };
        }
    }
}
