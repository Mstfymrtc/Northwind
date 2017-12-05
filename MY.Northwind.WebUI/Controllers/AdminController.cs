using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.Entity.Concrete;
using MY.Northwind.WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MY.Northwind.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private IProductService _productService;
        private ICategoryService _categoryService;


        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public ActionResult Index()
        {

            ProductListViewModel model = new ProductListViewModel
            {

                Products = _productService.GetAll()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            ProductAddViewModel model = new ProductAddViewModel
            {

                Product = new Product(),
                Categories = _categoryService.GetAll()


            };
            
            return View(model);


        }

        [HttpPost]
        public ActionResult Add(Product product)
        {

            //SERVER SIDE VALIDATION 
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added!");
            }
            //category dolamadığı için boş view a göndermiyoruz.
            //yani boş bir model gönderiyoruz.
            //actiona değil, direk view a gidiyor.
            //return View();
            return RedirectToAction("Add"); //direkt view'ı değil, aksiyonu aç
        }

        public ActionResult Update(int productId)
        {

            ProductUpdateViewModel model = new ProductUpdateViewModel()
            {
                Product=_productService.GetById(productId),
                Categories=_categoryService.GetAll()


            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Update(Product product)
        {

            //SERVER SIDE VALIDATION 
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Product was successfully updated!");
            }
       
            return RedirectToAction("Index"); //direkt view'ı değil, aksiyonu aç
        }

        public ActionResult Delete(int productId)
        {
            
           _productService.Delete(productId);
            TempData.Add("message", "Product was successfully deleted!");

            return RedirectToAction("Index");


        }
    }
}
