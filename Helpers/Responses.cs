using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
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
