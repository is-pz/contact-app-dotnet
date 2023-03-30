using contact_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace contact_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }
    }
}