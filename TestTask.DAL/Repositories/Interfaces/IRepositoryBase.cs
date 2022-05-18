using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);

        void Update(T entity);

        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
