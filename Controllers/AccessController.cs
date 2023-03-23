using contact_app.Models;
using contact_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


namespace contact_app.Controllers
{
    public class AccessController : Controller
    {
        private readonly IUserService crud;

        public AccessController(IUserService userService)
        {
            this.crud = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(String email, String password)
        {

            var user = crud.ValidateUser(email, password);

            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                HttpContext.Session.SetInt32("UserId", user.Id);

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
            HttpContext.Session.Clear();
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
            
            UserModel user = new UserModel
            {
                Name = collection["Name"],
                Email = collection["Email"],
                Password = collection["Password"] // TODO: Crear el hash de la contrasenia
            };

            bool result = crud.Add(user);

            if (!result)
            {
                ViewBag.Message = new MessageModel
                {
                    Message = "An error occurred while trying to register the account",
                    Type = "danger"
                };
                return View("Register");
            }

            return View("Index");
        }
      
    }
}
