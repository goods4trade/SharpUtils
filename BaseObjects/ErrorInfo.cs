using System;

namespace SharpUtils.BaseObjects
{
    public class ErrorInfo
    {
        public System.Web.Mvc.HandleErrorInfo StackTrace { get; set; }
        public string DomainName { get; set; }
        public string ErrorPageUrl { get; set; }
        public string IP { get; set; }
    }
}
