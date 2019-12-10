using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BlazorLoginDiscord.Data
{
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        public IDataProtectionProvider Provider { get; }

        public AccountController(IDataProtectionProvider provider)
        {
            Provider = provider;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, "Discord");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut(string returnUrl = "/")
        {
            //This removes the cookie assigned to the user login.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect(returnUrl);
        }
    }
}
