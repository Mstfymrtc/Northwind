using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.Dal.Abstract;
using MY.Northwind.Entity.Concrete;

namespace MY.Northwind.Bal.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal) //efproduct dal gelir, çünkü efproduct dal da bir IProductDal
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
           _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            
            _productDal.Delete(new Product{ProductID = productId});
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId==0);

        }

        public void Update(Product product)
        {
            _productDal.Update(product);

        }
    }
}
