using ContactApp.Core.Model;
using ContactApp.Core.Services.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactApp.Core.Services
{
    public interface IContactService
    {
        Contact CreateContact(
            CreateContactOptions options);

        bool EditContact(
            EditContactOptions options);

        bool DeleteContact(int? id);

        Contact SearchContact(int? id);

        IQueryable<Contact> SearchContact();
    }
}
