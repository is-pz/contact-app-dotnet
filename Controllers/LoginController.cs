using contact_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace contact_app.Controllers
{
    public class LoginController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View("Dashboard");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.Name = collection["Name"];
                user.Email = collection["Email"];
                user.Password = collection["Password"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
      
    }
}
