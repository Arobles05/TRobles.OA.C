

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TRobles.OA.C.Common.Interfaces;
using TRobles.OA.C.Entities;

namespace TRobles.OA.C.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;
        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public Task<Role> Autheticate(string userName, string password)
        {
            var user = _repository.GetById(1);

            return user ?? null;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Role> Get(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Role>> Get(Expression<Func<Role, bool>> whereCondition = null,
                           Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null,
                           string includeProperties = "")
        {
            return await _repository.GetPredicateAsync(whereCondition, orderBy, includeProperties);
        }

        public async Task<bool> Insert(Role role)
        {
            return await _repository.InsertAsync(role);
        }

        public void Update(Role role)
        {
            _repository.Update(role);
        }
    }
}
