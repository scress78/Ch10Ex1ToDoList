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
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;


        // changed from AccountController in Bookstore, different controller name here
        public Account(UserManager<User> userMngr,
            SignInManager<User> SignInMngr)
        {
            userManager = userMngr;
            signInManager = SignInMngr;
        }

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

        // following up on same issue with Views/Shared/_Layout, now need to make LogIn and register actually work
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // also had to be updated to match our current build
                // note below is weird looking. the actual file path is (appears to be) ToDoList/Models/DomainModels/User
                // however this pattern seems to match with bookstore
                // holy f*** it works!! now will add log-in/log-out
                var user = new ToDoList.Models.User
                {
                    UserName = model.Username,
                    // below not used currently, commenting out.
                    //Firstname = model.Firstname,
                    //Lastname = model.Lastname,
                    //Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpPost]
        // semi-obvious. allows log-out, then return to home
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        // would like to detail a little better in comments exactly what's happenign with these post requests, line by line
        // ie find the path to the model, find things like the LogIn function and trace what's happening
        // Login looks to just to be a declared function name here.
        // things like signInManger seem to be built-ins
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // UserName, Password, ReturnURL and Remember me all components of Models/ViewModels/LoginViewModel
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        // looks like if the string isn't (!) empty, and there's a match then actually login
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        // if log-in isn't successful go back home
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            // if there isn't a username/password that matches return an error
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
