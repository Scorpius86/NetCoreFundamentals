using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Fundamentals.OIC.Client.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => Challenge(new AuthenticationProperties { RedirectUri = "/" });
    }
}