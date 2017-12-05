using MY.Northwind.Core.Dal.EntityFramework;
using MY.Northwind.Dal.Abstract;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
