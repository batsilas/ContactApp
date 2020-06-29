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
    public class PhoneNumberService : IPhoneNumberService
    {
        private MyContactsDbContext context_;
        private IContactService contactService_;

        public PhoneNumberService(MyContactsDbContext context, IContactService contactService)
        {
            context_ = context;
            contactService_ = contactService;
        }

        //Create a new Phone Number for a Contact
        public PhoneNumber CreatePhoneNumber(CreatePhoneNumberOptions options)
        {
            if (options == null) {
                return null;
            }

            var contact = contactService_.SearchContact(options.ContactId);

            if (contact == null) {
                return null;
            }

            var phoneNumber = new PhoneNumber() { 
                Number = options.Number
            };

            contact.PhoneNumbers.Add(phoneNumber);
            context_.Update(contact);
            context_.Add(phoneNumber);

            if (context_.SaveChanges() > 0)
            {
                return phoneNumber;
            }

            return null;
        }

        //Edit an existing Phone Number by Contact
        public bool EditPhoneNumber(int? id, int? phoneNumberId, long? number) 
        {
            if (id == null || phoneNumberId == null) 
            {
                return false;
            }

            var phoneNumber = SearchPhoneNumber(id)
                .Where(p => p.PhoneNumberId == phoneNumberId)
                .SingleOrDefault();

            phoneNumber.Number = number.Value;

            if (context_.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        //Delete an existing Phone Number by Contact
        public void DeletePhoneNumber(PhoneNumber phoneNumber)
        {
            context_.Remove(phoneNumber);
            context_.SaveChanges();
        }

        //Search a Phone Number by Id
        public IQueryable<PhoneNumber> SearchPhoneNumber(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var query = context_
                .Set<PhoneNumber>()
                .Where(c => c.ContactId == id)
                .AsQueryable();

            if (query != null)
            {
                return query;
            }
            return null;
        }
        
        //Get All Contacts
        public IQueryable<PhoneNumber> SearchPhoneNumber()
        {
            var query = context_
                .Set<PhoneNumber>()
                .AsQueryable();

            if (query != null)
            {
                return query;
            }
            return null;
        }

     
    }
}
