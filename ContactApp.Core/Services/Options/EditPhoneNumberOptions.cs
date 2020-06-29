using ContactApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Services.Options
{
    public class EditPhoneNumberOptions
    {
        public Contact Contact { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set;}

        public EditPhoneNumberOptions()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}
