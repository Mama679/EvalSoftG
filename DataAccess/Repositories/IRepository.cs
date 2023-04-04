namespace DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Insert(T entity);
        void Delete(T entity);
        void SaveAll();
    }
}
