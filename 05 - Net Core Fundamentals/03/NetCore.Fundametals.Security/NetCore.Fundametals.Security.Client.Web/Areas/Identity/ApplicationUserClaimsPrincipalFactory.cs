using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetCore.Fundametals.Security.Client.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore.Fundametals.Security.Client.Web.Areas.Identity
{
    //Sin Role
    //public class ApplicationUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser>
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            //Con Roles
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ):base(userManager,roleManager,options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("CareerStarted", user.CareerStartedDate.ToShortDateString()));
            identity.AddClaim(new Claim("FullName", user.FullName));

            return identity;
        }
    }
}
