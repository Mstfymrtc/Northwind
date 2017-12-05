using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Bal.Concrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductID == product.ProductID);

            if (cartLine!=null)
            {
                cartLine.Quantity++;
                return;
            }

            cart.CartLines.Add(new CartLine
            {
                Product = product,
                Quantity = 1


            });
        }
            


        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {

            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(p => p.Product.ProductID == productId));

        }
    }
}
