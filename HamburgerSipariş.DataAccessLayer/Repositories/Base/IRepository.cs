using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HamburgerSiparis.DataAccessLayer.Repositories.Base
{
   
    public interface IRepository<T> where T : class
    {
        List<T> Listele();
        List<T> Listele(Expression<Func<T, bool>> kosul);
        void Ekle(T entity);
        void Guncelle(T entity);
        void Sil(T entity);
        T Bul(int id);
        T Bul(Expression<Func<T, bool>> kosul);
    }
}