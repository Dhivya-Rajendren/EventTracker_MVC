using Microsoft.AspNetCore.Mvc;
using EventTracker_MVC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace EventTracker_MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        DBHelper dbHelper;
        IConfiguration _configuration;
        string conString;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            conString = _configuration.GetConnectionString("EventDB");

        }

        public IActionResult Login(string returnUrl)
        {
            return View( new Login() { ReturnUrl=returnUrl});
        }

        [HttpPost]
        public  IActionResult Login(Login login)
        {
            dbHelper = new DBHelper(conString);
            var user = dbHelper.GetUserNameAndPassword(login.UserName, login.Password);

            if (user==false)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, login.UserName)

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
             HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return LocalRedirect(login.ReturnUrl);
        }

    }
}
