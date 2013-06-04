using System;
using System.Net;

namespace SharpUtils.BaseObjects
{
    public class HttpStatusMessage
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
    }
}
