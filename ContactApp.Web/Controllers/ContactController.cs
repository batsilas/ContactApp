using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Core.Data;
using ContactApp.Core.Model;
using ContactApp.Core.Services;
using ContactApp.Core.Services.Options;
using ContactApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactService contactService_;
        private IPhoneNumberService phoneNumberService_;
        private IWebHostEnvironment hostEnvironment_;
        public ContactController(IContactService contactService, IPhoneNumberService phoneNumberService, IWebHostEnvironment hostEnvironment)
        {
            contactService_ = contactService;
            phoneNumberService_ = phoneNumberService;
            hostEnvironment_ = hostEnvironment;
        }

        // Contacts Home Page
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new ContactViewModel()
            {
                Contacts = contactService_.SearchContact().ToList(),
                PhoneNumbers = phoneNumberService_.SearchPhoneNumber().ToList()
            };

            return View(viewModel);
        }

        // Create Contact Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create Contact Submit
        [HttpPost]
        public IActionResult Create(Contact contact, string btn)
        {
            if (contact == null) {
                return NotFound();
            }

            contact = contactService_.CreateContact(new CreateContactOptions()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Address = contact.Address
            });

            if (btn.Equals("AddPhoneNumbers"))
            {
                return RedirectToAction("AddPhoneNumbers");
            }
            else if (btn.Equals("Done"))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        // Edit Contact Form
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            var contact_ = contactService_
                .SearchContact(id);

            var phoneNumbers = phoneNumberService_
                .SearchPhoneNumber(id).ToList();

            var contactPhoneNumberViewModel = new ContactPhoneEditViewModel()
            {
                Contact = contact_,
                PhoneNumbers = phoneNumbers
            };

            return View(contactPhoneNumberViewModel);
        }

        // Edit Contact Submit
        [HttpPost]
        public IActionResult Edit(ContactPhoneEditViewModel contactPhoneEditViewModel, string btn)
        {
            bool success = contactService_.EditContact(
                new EditContactOptions()
                {
                    ContactId = contactPhoneEditViewModel.Contact.ContactId,
                    FirstName = contactPhoneEditViewModel.Contact.FirstName,
                    LastName = contactPhoneEditViewModel.Contact.LastName,
                    Email = contactPhoneEditViewModel.Contact.Email,
                    Address = contactPhoneEditViewModel.Contact.Address
                });

            if (success == true)
            {
                if (btn.Equals("EditPhoneNumbers"))
                {
                    return RedirectToAction("EditPhoneNumbers");
                }
                else if (btn.Equals("Done"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
            }
            else {
                return BadRequest();
            }
        }

        // Delete Contact by Id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            contactService_.DeleteContact(id);

            return RedirectToAction("Index");
        }

        // Add Phone Numbers Form
        [HttpGet]
        public IActionResult AddPhoneNumbers()
        {
            return View();
        }

        // Add Phone Numbers Submit
        [HttpPost]
        public IActionResult AddPhoneNumbers(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) {
                return NotFound();
            }

            long phoneLong = long.Parse(number);

            var contact_ = contactService_
                .SearchContact()
                .OrderByDescending(c => c.ContactId)
                .First();

            var phoneNumber = phoneNumberService_.CreatePhoneNumber(new CreatePhoneNumberOptions()
            {
                ContactId = contact_.ContactId,
                Number = phoneLong
            });

            contact_.PhoneNumbers.Add(phoneNumber);

            return View();
        }

        // Edit Phone Numbers Form
        [HttpGet]
        public IActionResult EditPhoneNumbers(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var contact_ = contactService_
                .SearchContact(id);

            var phoneNumbers = phoneNumberService_
                .SearchPhoneNumber(id).ToList();

            var contactPhoneNumberViewModel = new ContactPhoneEditViewModel()
            {
                Contact = contact_,
                PhoneNumbers = phoneNumbers
            };

            return View(contactPhoneNumberViewModel);
        }

        // Edit Phone Numbers Submit
        [HttpPost]
        public IActionResult EditPhoneNumbers(int? id, int? phoneNumberId, string number)
        {
            if (id == null || phoneNumberId == null) {
                return NotFound();
            }

            long phoneNumber = long.Parse(number);

            var success = phoneNumberService_.EditPhoneNumber(id, phoneNumberId, phoneNumber);

            if (success == true)
            {
                return RedirectToAction("EditPhoneNumbers");
            }
            else 
            {
                return BadRequest();
            }
        }

        // Show Contact Details
        [HttpGet]
        public IActionResult ShowDetails(int? id) 
        {
            if (id == null) {
                return NotFound();
            }

            var contact_ = contactService_
                .SearchContact(id);

            var phoneNumbers = phoneNumberService_
                .SearchPhoneNumber(id).ToList();

            var contactPhoneNumberViewModel = new ContactPhoneEditViewModel()
            {
                Contact = contact_,
                PhoneNumbers = phoneNumbers
            };

            return View(contactPhoneNumberViewModel);
        }
    }

}