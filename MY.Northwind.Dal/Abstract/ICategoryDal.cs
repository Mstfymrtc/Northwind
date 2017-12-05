using MY.Northwind.Core.Dal;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Dal.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

        //Her yerde gerekli olmayan, sadece category için lazım olan özel operasyonlar. (custom operations for category)
    }
}