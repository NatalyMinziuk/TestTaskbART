using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.DAL.Repositories.Realization
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TestTaskDBContext TestTaskDBContext { get; set; }

        public RepositoryBase(TestTaskDBContext testTaskDBContext)
        {
            this.TestTaskDBContext = testTaskDBContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.TestTaskDBContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            this.TestTaskDBContext.Set<T>().Update(entity);
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = this.GetQuery(predicate, include);
            return await query.FirstAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await this.GetQuery(predicate, include).FirstOrDefaultAsync();
        }

        private IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IQueryable<T>> sorting = null)
        {
            var query = this.TestTaskDBContext.Set<T>().AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (sorting != null)
            {
                query = sorting(query);
            }
            return query;
        }
    }
}
