using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.WebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }

    }
}
