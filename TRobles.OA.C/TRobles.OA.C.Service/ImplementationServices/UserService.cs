

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TRobles.OA.C.Common.Interfaces;
using TRobles.OA.C.Entities;

namespace TRobles.OA.C.Service
{
    public class UserService : IUserServise
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
           _repository = repository;
        }

        public Task<User> Autheticate(string userName, string password)
        {
            var user =  _repository.GetById(1);

            return user ?? null;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public async Task<IEnumerable<User>> Get()
        {
           return await _repository.GetAllAsync();
        }

        public async  Task<User> Get(long id)
        {
            return await  _repository.GetById(id);
        }

        public async Task<IEnumerable<User>> Get(Expression<Func<User, bool>> whereCondition = null,
                           Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
                           string includeProperties = "")
        {
            return await _repository.GetPredicateAsync(whereCondition, orderBy, includeProperties);
        }

        public async void Insert(User user)
        {
          var inserted = await  _repository.InsertAsync(user);
        }

        public  void Update(User user)
        {
            _repository.Update(user); 
        }
    }
}
