using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willian.Models;

namespace Willian.Controllers
{
    public class CategoriesController : Controller
    {
        private static IList<category> categoryList =
            new List<category>()
            {
                new category() {CategoryId = 1, Name = "Keybord"  },
                new category() {CategoryId = 2, Name = "Monitores"  },
                new category() {CategoryId = 3, Name = "Laptops"  },
                new category() {CategoryId = 4, Name = "Mouse"  },
                new category() {CategoryId = 1, Name = "Printer"  },
                
    };

        // GET: Categories
        public ActionResult Index()
                    
        {
            //SELECT*
            //FROM categories 
            //ORDER BY categories.name
            return View(categoryList.OrderBy(c => c.Name));  //Depois do ponto código para ordenar a lista.
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(category category)
        {
            categoryList.Add(category);
                category.CategoryId =
                categoryList.Max(c => c.CategoryId) + 1;
            return RedirectToAction("Create");
        }



 
        public ActionResult Details(long id)
        {
            var category = categoryList
                .Where(C => C.CategoryId == id)
                .First();
                      
            return View(category);
        }

       
        public ActionResult Edit (long id)
         


        {
            var category = categoryList
                .Where(C => C.CategoryId == id)
                .First();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(category modified)
        {
            var category = categoryList
                           .Where(C => C.CategoryId == modified.CategoryId)
                           .First();

            category.Name = modified.Name;

            return RedirectToAction("Index");
            
        }

        
        public ActionResult Delete (long id)



        {
            var category = categoryList
                .Where(C => C.CategoryId == id)
                .First();

            return View(category);
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Delete (category toDelete)
        {
            var category = categoryList
                           .Where(C => C.CategoryId == toDelete.CategoryId)
                           .First();

            category.Name = toDelete.Name;

            return RedirectToAction("Index");

        }










    }
}