using System;
using System.Net;

namespace MAXX.Utils.BaseObjects
{
    public class HttpStatusMessage
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
    }
}
