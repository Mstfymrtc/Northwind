using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MY.Northwind.Entity.Concrete;
using MY.Northwind.WebUI.ExtensionMethods;


namespace MY.Northwind.WebUI.Services
{
    public class CartSessionService : ICartSessionService
    {

        private IHttpContextAccessor _httpContextAccessor;
        


        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        //sessionlar normalde default olarak controllerde kullanılmak üzere ayarlanmışlardır.
        //sessionları controller haricinde bir çok yerde kullanmak için yukarıdaki işleme ihtiyaç duyarız.

        public Cart GetCart()
        {
            Cart cartToCheck=_httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck==null) 
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);

        }
    }
}
