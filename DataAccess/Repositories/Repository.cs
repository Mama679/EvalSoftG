using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TravelContext _db;
        internal DbSet<T> dbset;

        public Repository(TravelContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
           
        }
        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = dbset.ToList();
            return query;
        }

        public T GetById(int Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public void SaveAll()
        {
            _db.SaveChanges();
        }
    }
}
