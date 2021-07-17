using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TRobles.OA.C.Entities;

namespace TRobles.OA.C.Service
{
    public interface IRoleService
    {
        Task<Role> Autheticate(string userName, string password);
        Task<IEnumerable<Role>> Get();
        Task<Role> Get(long id);
        Task<IEnumerable<Role>> Get(Expression<Func<Role, bool>> whereCondition = null,
                           Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null,
                           string includeProperties = "");
        Task<bool> Insert(Role role);
        void Update(Role role);
        void Delete(long id);
    }
}
