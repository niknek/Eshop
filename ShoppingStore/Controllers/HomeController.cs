using PagedList;
using ShoppingStore.Models;
using ShoppingStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private List<Item> GetTopSeelingItems(int count)
        {
            return db.Items.OrderByDescending(i => i.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
        public ActionResult Index(int? page,string searchstring, string currentFilter)
        {
            var items = GetTopSeelingItems(1000);

            if (searchstring != null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentFilter;
            }

            ViewBag.CurrentFilter = searchstring;

            var students = from i in db.Items
                           select i;
            if (!String.IsNullOrEmpty(searchstring))
            {
                items = items.Where(i => i.Title.Contains(searchstring)
                                       || i.Description.Contains(searchstring)).ToList();
            }

            int pageSize = 6;
            int pageNumber = page ?? 1;
            return View(items.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}