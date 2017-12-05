using MY.Northwind.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MY.Northwind.Entity.Concrete
{
    public class Product:IEntity
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}