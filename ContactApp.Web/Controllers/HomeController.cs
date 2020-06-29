using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactApp.Web.Models;
using ContactApp.Core.Data;
using ContactApp.Core.Services;
using ContactApp.Core.Services.Options;
using Microsoft.AspNetCore.Hosting;

namespace ContactApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IContactService contactService_;
        private IPhoneNumberService phoneNumberService_;
        private IWebHostEnvironment hostEnvironment_;
        public HomeController(IContactService contactService, IPhoneNumberService phoneNumberService, IWebHostEnvironment hostEnvironment)
        {
            contactService_ = contactService;
            phoneNumberService_ = phoneNumberService;
            hostEnvironment_ = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
