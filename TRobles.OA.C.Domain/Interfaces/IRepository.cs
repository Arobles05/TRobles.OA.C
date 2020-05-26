using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TRobles.OA.C.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPredicateAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        Task<T> GetById(long id);
        //Task<T> GetPagedList<T>(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
        Task<bool> InsertAsync(T entity);
        void Update(T entity);
        void Delete(long id);

    }
}
