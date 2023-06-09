﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using contact_app.Services;
using contact_app.Models;

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
            int UserId = int.Parse(User.Claims.First().Value);
            List<ContactModel> contacts = crud.GetAll(UserId);
            ViewBag.Contacts = contacts;
            return View();
        }

    }
}
