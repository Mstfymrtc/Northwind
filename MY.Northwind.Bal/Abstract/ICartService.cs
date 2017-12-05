using System;
using System.Collections.Generic;
using System.Text;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Bal.Abstract
{
    public interface ICartService
    {

        void AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, int productId);
        List<CartLine> List(Cart cart);

    }
}
