using System;
using System.Collections.Generic;
using System.Text;
using MY.Northwind.Core.Dal.EntityFramework;
using MY.Northwind.Dal.Abstract;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
    }

  
}
