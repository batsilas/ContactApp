
using ContactApp.Core.Model;
using ContactApp.Core.Services.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactApp.Core.Services
{
    public interface IPhoneNumberService
    {
        PhoneNumber CreatePhoneNumber(
            CreatePhoneNumberOptions options);

        bool EditPhoneNumber(
            int? id, int? phoneNumberId, long? phoneNumber);

        void DeletePhoneNumber(PhoneNumber phoneNumber);

        IQueryable<PhoneNumber> SearchPhoneNumber(int? id);

        IQueryable<PhoneNumber> SearchPhoneNumber();

    }

   
}
