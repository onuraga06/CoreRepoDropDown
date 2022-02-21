using CoreGenericRepo.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGenericRepo.Controllers.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private DataBaseContext db;
        public BaseRepository(DataBaseContext _db)
        {
            db = _db;
        }
        public void Add(T entity)
        {
            Set().Add(entity);
        }

        public T Bul(int id)
        {
           return Set().Find(id);
        }

        public void Delete(T entity)
        {

            Set().Remove(entity);
        }

        public IQueryable<T> GetAllList()
        {
            return Set().AsQueryable();
        }

        public List<T> GetList()
        {
            return Set().ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return db.Set<T>();
        }
    }
}
