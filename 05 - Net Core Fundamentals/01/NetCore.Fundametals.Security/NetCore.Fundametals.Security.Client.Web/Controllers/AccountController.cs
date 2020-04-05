using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundametals.Security.Client.Web.Models;
using NetCore.Fundametals.Security.Client.Web.SchemeAuthentication;
using NetCore.Fundametals.Security.Data.Model;
using NetCore.Fundametals.Security.Data.Repositories;

namespace NetCore.Fundametals.Security.Client.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl="/")
        {
            return View(new LoginViewModel { ReturnUrl=returnUrl});
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User user = _userRepository.GetByUsernameAndPassword(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("FavoriteColor",user.FavoriteColor)
            };

            ClaimsIdentity identity = new ClaimsIdentity(
                claims, 
                CookieAuthenticationDefaults.AuthenticationScheme
            );
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                principal, 
                new AuthenticationProperties { IsPersistent = model.RememberLogin }
            );

            return LocalRedirect(model.ReturnUrl);
        }

        [AllowAnonymous]
        public IActionResult LoginWithGoogle(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties {
                RedirectUri = Url.Action("GoogleLoginCallback"),
                Items =
                {
                    { "returnUrl", returnUrl }
                }
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallbackAsync()
        {
            var result = await HttpContext.AuthenticateAsync(ExternalAuthenticationDefaults.AuthenticationScheme);
            var externalClaims = result.Principal.Claims.ToList();
            var subjectIdClaim = externalClaims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            var subjectValue = subjectIdClaim.Value;

            User user = _userRepository.GetByGoogleId(subjectValue);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("FavoriteColor",user.FavoriteColor)
            };

            ClaimsIdentity identity = new ClaimsIdentity(
               claims,
               CookieAuthenticationDefaults.AuthenticationScheme
           );
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignOutAsync(ExternalAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(result.Properties.Items["returnUrl"]);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}