using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using contact_app.Services;
using contact_app.Models;
using Microsoft.AspNetCore.Identity;

namespace contact_app.Controllers
{
    [Authorize] //Restringiendo acceso
    public class DashboardController : Controller
    {
        private readonly IContactService crud;

        public DashboardController(IContactService contactService) 
        {
            this.crud = contactService;
        }

        public ActionResult Index()
        {
            User.ToString();
            List<Contact> contacts = crud.GetAll(1);
            ViewBag.Contacts = contacts;
            return View();
        }

    }
}
