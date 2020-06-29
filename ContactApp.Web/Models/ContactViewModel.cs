using ContactApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Web.Models
{
    public class ContactViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }

        public ContactViewModel() {
            Contacts = new List<Contact>();
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}
