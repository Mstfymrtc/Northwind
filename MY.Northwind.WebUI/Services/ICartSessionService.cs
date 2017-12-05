using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.WebUI.Services
{
    public interface ICartSessionService
    {

        Cart GetCart();
        void SetCart(Cart cart);

    }
}
