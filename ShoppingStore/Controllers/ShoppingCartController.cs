using ShoppingStore.Models;
using ShoppingStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);


            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {

            var addedItem = db.Items
                .Single(item => item.ItemId == id);


            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedItem);


            return RedirectToAction("Index");
        }

        
        public ActionResult RemoveFromCart(int id,string cartID )
        {
            
            Cart cart = db.Carts.Single(x => x.CartId == cartID && x.ItemId == id);
            db.Carts.Remove(cart);
            db.SaveChanges();



            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}