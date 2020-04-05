using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.FSI.Client.Web.Data
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public DateTime CareerSatarted { get; set; }
        public string FullName { get; set; }
    }
}
