using System;
using System.Collections.Generic;
using System.Text;
using MY.Northwind.Core.Entity;

namespace MY.Northwind.Entity.Concrete
{
    public class Category:IEntity // IEntity: Category, bir veritabanı nesnesidir.
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
