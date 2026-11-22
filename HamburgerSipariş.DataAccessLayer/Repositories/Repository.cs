using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.DataAccessLayer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HamburgerSiparis.DataAccessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected HamburgerContext context;
        protected DbSet<T> dbSet;

       
        public Repository(HamburgerContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Ekle(T entity)
        {
            dbSet.Add(entity);
        }

        public T Bul(int id)
        {
            return dbSet.Find(id);
        }

        public T Bul(Expression<Func<T, bool>> kosul)
        {
            return dbSet.FirstOrDefault(kosul);
        }

        public void Guncelle(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public List<T> Listele()
        {
            return dbSet.ToList();
        }

        public List<T> Listele(Expression<Func<T, bool>> kosul)
        {
            return dbSet.Where(kosul).ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}