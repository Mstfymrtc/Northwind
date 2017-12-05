using System;
using System.Collections.Generic;
using System.Text;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.Dal.Abstract;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Bal.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
