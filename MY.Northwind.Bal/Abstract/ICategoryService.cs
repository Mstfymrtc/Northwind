using System.Collections.Generic;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Bal.Abstract
{
    public interface ICategoryService
    {

        List<Category> GetAll();

      
    }
}