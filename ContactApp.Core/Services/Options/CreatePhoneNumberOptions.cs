using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Services.Options
{
    public class CreatePhoneNumberOptions
    {
        public int ContactId { get; set; }
        public long Number { get; set; }
    }
}
