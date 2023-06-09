﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using contact_app.Services;
using contact_app.Models;

namespace contact_app.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {

        private readonly IContactService _crud;

        public ContactController(IContactService _contactService) 
        {
            this._crud = _contactService;
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
                ContactModel contact = new ContactModel
                {
                    UserId = int.Parse(User.Claims.First().Value),
                    Name = collection["Name"],
                    PhoneNumber = int.Parse(collection["PhoneNumber"].ToString())
                };

                bool contactCreated = _crud.Create(contact);
                
                ViewBag.Message = new MessageModel
                {
                    Message = (contactCreated) ? "Added successfully" : "Failed to add",
                    Type = (contactCreated) ? "success" : "danger" 
                };
                
            }catch
            {
                ViewBag.Message = new MessageModel
                {
                    Message = "Failed to perform action",
                    Type =  "danger"
                };
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult Edit(int id)
        {
            int userId = int.Parse(User.Claims.First().Value);
            ContactModel contact = _crud.Get(id, userId);

            ViewBag.Contact = contact;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                int userId = int.Parse(User.Claims.First().Value);
                ContactModel contact = new ContactModel
                {
                    Id = int.Parse(collection["id"].ToString()),
                    UserId = userId,
                    Name = collection["Name"],
                    PhoneNumber = int.Parse(collection["PhoneNumber"].ToString())
                };

                bool updateContact = _crud.Update(contact);

                ContactModel newDataContact = _crud.Get(contact.Id, userId);
                ViewBag.Contact = newDataContact;

                ViewBag.Message = new MessageModel
                {
                    Message = (updateContact) ? "Updated successfully" : "Failed to update",
                    Type = (updateContact) ? "success" : "danger"
                };
            }
            catch
            {
                ViewBag.Message = new MessageModel
                {
                    Message = "Failed to perform action",
                    Type = "danger"
                };
            }

            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                bool deletedContact = _crud.Delete(id);
                ViewBag.Message = new MessageModel
                {
                    Message = (deletedContact) ? "Deleted successfully" : "Failed to delete",
                    Type = (deletedContact) ? "success" : "danger"
                };
            }
            catch
            {
                ViewBag.Message = new MessageModel
                {
                    Message = "Failed to perform action",
                    Type = "danger"
                };
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
