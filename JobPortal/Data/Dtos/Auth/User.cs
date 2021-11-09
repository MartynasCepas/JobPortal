using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Data.Dtos.Auth
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string AdditionalInfo { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}
