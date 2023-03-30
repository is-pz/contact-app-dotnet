using contact_app.Models;
using contact_app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace contact_app.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _crud;

        public UserController(IUserService userService)
        {
            this._crud = userService;
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.UserId = int.Parse(User.FindFirst("NameIdentifier").Value);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(IFormCollection collection)
        {
            try
            {
                UserModel userData = _crud.Get(int.Parse(User.FindFirst("NameIdentifier").Value));

                userData.Password = collection["NewPassword"];

                _crud.Update(userData);

                ViewBag.Message = new MessageModel
                {
                    Message = "Password changed successfully",
                    Type =  "success"
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
            return View();
        }

       
    }
}
