using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.Business.Abstract
{
    public interface IGenericService<T>
    {
        Task<T> AddAsync(T model);
        Task<int> CountAsync();
        Task<T> DeleteAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter);
    }
}
