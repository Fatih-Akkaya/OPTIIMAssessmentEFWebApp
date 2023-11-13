using AssessmentEF.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.Business.Abstract
{
    public interface IPersonnelService : IGenericService<Personnel>
    {
        Task<Personnel> GetPersonnelByIdAsync(int id);
    }
}
