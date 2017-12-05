using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.Entity.Concrete;
using MY.Northwind.WebUI.Services;
using MY.Northwind.WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MY.Northwind.WebUI.Controllers
{
    public class CartController : Controller
    {

        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(IProductService productService, ICartService cartService, ICartSessionService cartSessionService)
        {
            _productService = productService;
            _cartService = cartService;
            _cartSessionService = cartSessionService;
        }

        // GET: /<controller>/
        public ActionResult AddToCart(int productId)
        {

            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded);


            // ekledikten sonra cart ı yeniden session a atmam gerek.
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Your product {0} has been successfully added to the cart!", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product");



        }

        public ActionResult List()
        {

            var cart=_cartSessionService.GetCart();

            CartListViewModel cartListViewModel = new CartListViewModel()
            {

                Cart = _cartSessionService.GetCart()

            };
            return View(cartListViewModel);

        }

        public ActionResult Remove(int productId)
        {

            var cart = _cartSessionService.GetCart();

            _cartService.RemoveFromCart(cart,productId);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("Your product has been successfully removed to the cart!"));


            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            ShippingDetailsViewModel model = new ShippingDetailsViewModel
            {

                ShippingDetails = new ShippingDetails()

            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {

            if (ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message",string.Format("Thank you {0}, your order is in process.", shippingDetails.FirstName));
            return View();
        }
    }
}
