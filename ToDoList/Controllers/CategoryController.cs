using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;


// using ideas from Ch 14 as reference. something still wrong, not sure what
namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {
        private Repository<Category> categories { get; set; }
        public CategoryController(ToDoContext ctx) => categories = new Repository<Category>(ctx);

        public ViewResult Index()
        {
            var options = new QueryOptions<Category>
            {
                OrderBy = t => t.Name
            };
            return View(categories.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                categories.Insert(category);
                categories.Save();
                TempData["msg"] = $"{category.CatName} added to list of teachers";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(categories.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Category category)
        {
            category = categories.Get(category.CategoryId); // so can get teacher name for notification message
            categories.Delete(category);
            categories.Save();
            TempData["msg"] = $"{category.CatName} removed from list of teachers";
            return RedirectToAction("Index");
        }
    }
}
