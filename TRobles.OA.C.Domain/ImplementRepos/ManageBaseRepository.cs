using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TRobles.OA.C.Common.Interfaces;

namespace TRobles.OA.C.Common.ImplementRepos
{
    public class ManageBaseRepository<T, C> : IRepository<T> where T : class, new() where C : DbContext
    {
        private string _errorMessage;
        private bool _isDisposesd;
        private readonly IUnitOfWork _unitOfWork;
        private DbSet<T> _entity;
        private readonly C _context;

        public ManageBaseRepository(IUnitOfWork unit, C context)
        {
            this._unitOfWork = unit;
            this._context = context;
            this._entity = _context.Set<T>();
            this._errorMessage = string.Empty;
        }
        public void Delete(long id)
        {
            try
            {
                T objectInDb = _entity.Find(id);
                if(objectInDb != null)
                {
                    _entity.Remove(objectInDb);
                    _unitOfWork.Commit();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                _unitOfWork.Rollback();
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync(); //  AsEnumerable<T>();
        }
        public async Task<T> GetById(long id)
        {
           return await _entity.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetPredicateAsync(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this._entity;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<bool> InsertAsync(T entity)
        {
            bool created =  false;
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var entitySaved = await  _entity.AddAsync(entity);
                if(entitySaved!= null) { 
                    created = true;
                    _unitOfWork.Save();
                   //_unitOfWork.Commit();
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                _unitOfWork.Rollback();
                throw new Exception(_errorMessage, dbEx);
            }

            return created;
        }
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entityAttached =   _entity.Attach(entity);
                SetEntryModified(entity);
                _unitOfWork.Commit();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                _unitOfWork.Rollback();
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public IPagedList<T> GetPaged(int pageIndex, int pageSize, string sortExpression = null)
        {
            var query = _entity.AsNoTracking();

            return new PagedList<T>(query, (pageIndex * pageSize) - pageSize, pageSize);
        }
        public IPagedList<T> GetPaged(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null)
        {
            var query = filter == null ? _entity.AsNoTracking() : _entity.AsNoTracking().Where(filter);
            var notSortedResults = transform(query);

            return new PagedList<T>(notSortedResults, (pageIndex * pageSize) - pageSize, pageSize);
        }
        public IPagedList<TResult> GetPaged<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null, int pageIndex = -1, int pageSize = -1, string sortExpression = null)
        {
            var query = filter == null ? _entity.AsNoTracking() : _entity.AsNoTracking().Where(filter);
            var notSortedResults = transform(query);

            return new PagedList<TResult>(notSortedResults, (pageIndex * pageSize) - pageSize, pageSize);
        }
        public virtual void SetEntryModified(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            _isDisposesd = true;
        }
    }
}
