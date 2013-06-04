using System;

namespace SharpUtils.BaseObjects
{
    public class TransactionStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public TransactionStatus()
        {
            Message = string.Empty;
            Success = true;
        }

    }
}
