using Microsoft.EntityFrameworkCore;
using SMIS.DAL.Context;
using SMIS.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SMIS.DAL.Repositories.Ef
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SchoolManagementDbContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(SchoolManagementDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public T GetById(int id) => _table.Find(id);

        public List<T> GetAll() => _table.ToList();

        public List<T> Where(Expression<Func<T, bool>> predicate)
            => _table.Where(predicate).ToList();

        public void Add(T entity) => _table.Add(entity);

        public void Update(T entity) => _table.Update(entity);

        public void Delete(T entity) => _table.Remove(entity);

        public void Save() => _context.SaveChanges();
    }
}

