using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Controllers.Repository
{
   public interface IBaseRepository<T> where T:class,new()
    {
        DbSet<T> Set();
        List<T> GetList();
        T Bul(int id);
        IQueryable<T> GetAllList();
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
