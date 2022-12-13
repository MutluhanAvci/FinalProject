using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context=new NorthwindContext())//C#'a özel bir yapıdır.
                                                                            //Garbage collectora işin bitince hemen bellekten at demektir.
            {
                var addedEntity = context.Entry(entity);//Referans yakala
                addedEntity.State = EntityState.Added;//Eklenecek nesne olduğunu anla
                context.SaveChanges();//Değişiklikleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
                                                                     
            {
                var deletedEntity = context.Entry(entity);//Referans yakala
                deletedEntity.State = EntityState.Deleted;//Silinecek nesne olduğunu anla
                context.SaveChanges();//Değişiklikleri kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
                //Tek bir data döndürür, standarttır.
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
                //ternany operatörü
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())

            {
                var updatedEntity = context.Entry(entity);//Referans yakala
                updatedEntity.State = EntityState.Modified;//Güncellenecek nesne olduğunu anla
                context.SaveChanges();//Değişiklikleri kaydet
            }
        }
    }
}
