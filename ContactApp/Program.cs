using ContactApp.Core.Data;
using ContactApp.Core.Model;
using ContactApp.Core.Services;
using ContactApp.Core.Services.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            //using (var context = new MyContactsDbContext())
            //{
            //    IContactService contactService = new ContactService(
            //        context);
            //    IPhoneNumberService phoneNumberService = new PhoneNumberService(
            //        context, contactService);

                //var contact = contactService.SearchContact(1).SingleOrDefault();

                //var contact = contactService.CreateContact(
                //new CreateContactOptions()
                //{
                //    FirstName = "Fotis",
                //    LastName = "Botsi",
                //    Email = "botsi@gmail.com",
                //}) ;

                //var contact1 = contactService.GetContactById(1);

                //phoneNumberService.CreatePhoneNumber(new CreatePhoneNumberOptions
                //{
                //    ContactId = contact1.ContactId,
                //    Number = 698452
                //});

                //phoneNumberService.CreatePhoneNumber(new CreatePhoneNumberOptions
                //{
                //    ContactId = contact1.ContactId,
                //    Number = 699886
                //});

                //var contacts = new List<Contact>();

                
                //contacts = contactService.GetAllContacts();

                //foreach (var item in contact1.PhoneNumbers)
                //{
                //    Console.WriteLine(item.Number);
                //}

            //}
        }
    }
}
