using ShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.Controllers
{
    public class StoreController : Controller
    {

        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
            var category = db.Categories.ToList();

            return View(category);
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }


        public ActionResult Browse(string category)
        {
            var categoryModel = db.Categories.Include("Items")
                .Single(c=>c.Name==category);
            return View(categoryModel);
        }
        public ActionResult Details(int id)
        {
            var Item = db.Items.Find(id);
            return View(Item);
        }
       
    }
}