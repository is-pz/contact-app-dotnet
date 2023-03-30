using contact_app.Models;
using contact_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using contact_app.Utilities;

namespace contact_app.Controllers
{
    public class AccessController : Controller
    {
        private readonly IAccessService _crud;
        private PasswordUtilities passwordUtilities;

        public AccessController(IAccessService accessService)
        {
            this._crud = accessService;
            this.passwordUtilities = new PasswordUtilities();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(String email, String password)
        {

            var user = _crud.ValidateUser(email, password);

            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Message = new MessageModel {
                Message = "Invalid email or password",
                Type = "warning",
            };
            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            string hashedPassword = passwordUtilities.GetHashPassword(collection["Password"].ToString());

            UserModel user = new UserModel
            {
                Name = collection["Name"],
                Email = collection["Email"],
                Password = hashedPassword
            };

            bool result = _crud.Add(user);

            if (!result)
            {
                ViewBag.Message = new MessageModel
                {
                    Message = "An error occurred while trying to register the account",
                    Type = "danger"
                };
                return View("Register");
            }
            ViewBag.Message = new MessageModel
            {
                Message = "Registered successfully",
                Type = "success"
            };
            return View("Index");
        }
      
    }
}
