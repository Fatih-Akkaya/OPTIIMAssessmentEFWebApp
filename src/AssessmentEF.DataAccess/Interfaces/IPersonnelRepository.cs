using AssessmentEF.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.DataAccess.Interfaces
{
    public interface IPersonnelRepository : IAsyncRepository<Personnel>
    {
        Task<Personnel> AddPersonnelAsync(Personnel personnel);
        Task<Personnel> UpdatePersonnelAsync(Personnel personnel);
        Task<Personnel> GetPersonnelWithSalary(Expression<Func<Personnel, bool>> filter);
    }
}
