using MY.Northwind.Core.Dal;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Dal.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {

//Her yerde gerekli olmayan, sadece product için lazım olan özel operasyonlar. (custom operations for product)
    }
}
