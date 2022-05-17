using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("userName");
            return View();
        }

        public IActionResult Login()
        {
            UserViewModel model = new UserViewModel();
            model.ReturnUrl = Request.HttpContext.Session.GetString("returnUrl");
            return View(model);
        }


        [HttpPost]
        public IActionResult Login(UserViewModel model)
        {
         
            if((model.Password=="123" && model.UserName=="yzc") || (model.Password=="asd" && model.UserName=="asd"))
            {
                //   Request.HttpContext.Session.Add("user",model);
                HttpContext.Session.SetString("userName", model.UserName);
                // return RedirectToAction("Index", "WordDefinition");
                if(String.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "WordDefinition");
                }
                return Redirect(model.ReturnUrl);
            }
            ModelState.AddModelError("", "Kullancı adı veya parola hatalı");
            return View(model);

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("userName", "");
            return RedirectToAction("Login");
        }
    }
}
