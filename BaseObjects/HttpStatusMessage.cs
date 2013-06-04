using System;
using System.Net;

namespace SharpUtil.BaseObjects
{
    public class HttpStatusMessage
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
    }
}
