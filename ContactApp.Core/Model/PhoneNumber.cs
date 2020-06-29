using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Model
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public long Number { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        
    }
}
