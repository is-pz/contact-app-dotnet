using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using contact_app.Services;
using contact_app.Models;

namespace contact_app.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {

        private readonly IContactService crud;

        public ContactController(IContactService _contactService) 
        {
            this.crud = _contactService;
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Contact contact = new Contact
                {
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    Name = collection["Name"],
                    PhoneNumber = int.Parse(collection["PhoneNumber"].ToString())
                };

                bool UserCreated = crud.Create(contact);

                ViewBag.Message = (!UserCreated) ? "Ocurrio un error al agregar el contacto" : "Se agrego el contacto";
       
                return RedirectToAction("Index", "Dashboard");

            }catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            Contact contact = crud.Get(id, userId);

            ViewBag.Contact = contact;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                int userId = (int)HttpContext.Session.GetInt32("UserId");
                Contact contact = new Contact
                {
                    Id = int.Parse(collection["id"].ToString()),
                    UserId = userId,
                    Name = collection["Name"],
                    PhoneNumber = int.Parse(collection["PhoneNumber"].ToString())
                };

                crud.Update(contact);

                return RedirectToAction("Edit", "Contact", int.Parse(collection["id"].ToString()));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                crud.Delete(id);
                return RedirectToAction("Index", "Dashboard");
            }
            catch
            {
                return View();
            }
        }
    }
}
