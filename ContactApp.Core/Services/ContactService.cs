using ContactApp.Core.Data;
using ContactApp.Core.Model;
using ContactApp.Core.Services.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactApp.Core.Services
{
    public class ContactService : IContactService
    {
        private MyContactsDbContext context_;

        public ContactService(MyContactsDbContext context) {
            context_ = context;
        }

        //Create a new Contact
        public Contact CreateContact(CreateContactOptions options)
        {
            if (options == null) {
                return null;
            }

            var contact = new Contact() {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                Address = options.Address,
                PhoneNumbers = options.PhoneNumbers
            };

            context_.Add(contact);

            if (context_.SaveChanges() > 0)
            {
                return contact;
            }

            return null;
        }

        //Delete an existing Contact
        public bool DeleteContact(int? id)
        {
            if (id == null) {
                return false;
            }
            var contact = SearchContact(id);
            
            context_.Remove(contact);
            context_.SaveChanges();

            return true;
        }

        //Edit an existing Contact
        public bool EditContact(EditContactOptions options)
        {
            if (options == null)
            {
                return false;
            }

            var contact = SearchContact(options.ContactId);

            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                contact.FirstName = options.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(options.LastName))
            {
                contact.LastName = options.LastName;
            }
                       
            contact.Email = options.Email;
           
            contact.Address = options.Address;
            
            if (options.PhoneNumbers != null)
            {
                contact.PhoneNumbers = options.PhoneNumbers;
            }

            if (context_.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        //Search a Contact by Id
        public Contact SearchContact(int? id) 
        {
            if (id == null)
            {
                return null;
            }

            var contact = context_
                .Set<Contact>()
                .Where(c => c.ContactId == id)
                .Include(p => p.PhoneNumbers)
                .SingleOrDefault();

            return contact;

        }

        //Get all Contacts
        public IQueryable<Contact> SearchContact()
        {

            var query = context_
               .Set<Contact>()
               .AsQueryable();
            
            return query;

        }

    }
}
