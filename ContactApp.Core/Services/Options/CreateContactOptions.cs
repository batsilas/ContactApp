using ContactApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Services.Options
{
    public class CreateContactOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
