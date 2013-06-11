namespace SharpUtils.BaseObjects
{
    public class HttpStatusMessage : HttpMessage
    {
        public int Status { get; set; }        
        public string MessageDetail { get; set; }
    }
}
