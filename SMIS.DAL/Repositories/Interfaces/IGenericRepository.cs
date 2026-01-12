using System.Linq.Expressions;

namespace SMIS.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Save();
    }
}
