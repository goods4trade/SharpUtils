using System;
using System.ComponentModel.DataAnnotations;

namespace MAXX.Utils.BaseObjects
{
    public class ContactInfo
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [EmailAddress]
        public string ToEmail { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
