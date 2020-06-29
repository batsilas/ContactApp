using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ContactApp.Core.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }

        public Contact()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}
