using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MY.Northwind.Core.Entity;

namespace MY.Northwind.Core.Dal
{
    public interface IEntityRepository<T> where T:class,IEntity,new() 
        //IEntity'den implemente 
        //edilmiş(buraya ancak veritabanı nesnesini yazabilirsin
    {

        T Get(Expression<Func<T,bool>> filter=null); //nesne çağırmak

        List<T> GetList(Expression<Func<T, bool>> filter = null); //nesne listesi çağırmak

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
