using System;
using Microsoft.AspNetCore.Mvc;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.WebUI.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace MY.Northwind.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(int page=1,int category=0) //category id 0 bulamadığı için hepsini gösterecek.
        {

            int pageSize = 10; //her bir sayfadaki ürün sayısı

            var products = _productService.GetByCategory(category);

            ProductListViewModel model = new ProductListViewModel
            {
                
                Products=products.Skip(pageSize*(page-1)).Take(pageSize).ToList(),
                PageCount=(int)Math.Ceiling(products.Count/(double)pageSize), //oluşturulacak linklerin sayısı
                PageSize=pageSize,
                CurrentCategory=category,
                CurrentPage=page
            };
            return View(model);
            
        }

        //public string Session()
        //{
        //    //kullanmak istediğimiz nesneyi tutmak için string çevirme işlemi yapıyoruz. (serialize)
        //    //lazım olduğunda ise tekrar nesne haline çeviriyoruz(deserialize)

        //    HttpContext.Session.SetString("city","Ankara");
        //    HttpContext.Session.SetInt32("age",32);

        //    HttpContext.Session.GetString("city");
        //    HttpContext.Session.GetInt32("age");
        //}

    }
}
