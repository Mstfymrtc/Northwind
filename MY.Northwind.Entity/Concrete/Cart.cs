using System.Collections.Generic;
using System.Linq;

namespace MY.Northwind.Entity.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines=new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }

        public decimal Total
        {

            get { return CartLines.Sum(p => p.Product.UnitPrice * p.Quantity); }
        }

    }
}