using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TRobles.OA.C.Entities;

namespace TRobles.OA.C.Service
{
  public interface IUserService
    {
        Task<User> Autheticate(string userName, string password);
        Task<IEnumerable<User>> Get();
        Task<User> Get(long id);
        Task<IEnumerable<User>> Get(Expression<Func<User, bool>> whereCondition = null,
                           Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
                           string includeProperties = "");
        Task<bool> Insert(User user);
        void Update(User user);
        void Delete(long id);
    }
}
