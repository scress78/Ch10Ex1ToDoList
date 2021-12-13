using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ToDoList.Models;

using System;
using System.Collections.Generic;
using System.Linq;


namespace ToDoList.Controllers
{
    public class Account : Controller
    {
        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpGet] //make a new url work this way.. first make a model, then a view, then configure in controller
        public IActionResult Register()
        {
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
