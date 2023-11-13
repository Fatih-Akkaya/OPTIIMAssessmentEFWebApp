using AssessmentEF.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.DataAccess.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseModel
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IReadOnlyList<T>> ListAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<int> CountAsync();
    }
}
