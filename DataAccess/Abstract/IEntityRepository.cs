using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic constraint=>T'yi sınırlandırmak
    //Class ifadesi classlar için değil referans tipler içindir interface vb.
    //IEntity => IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() ifadesi ise newlenebilen kavramlar içindir.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //<T> genericleri gösterir
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //Expression denir.Bir delegedir.
        //Bunun sayesinde ayrı ayrı kategoriye göre getir vb. methodları yazmaktan kurtuluruz
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        

    }
}
