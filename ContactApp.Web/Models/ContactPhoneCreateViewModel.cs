using ContactApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Web.Models
{
    public class ContactPhoneCreateViewModel
    {
        public Contact Contact { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
