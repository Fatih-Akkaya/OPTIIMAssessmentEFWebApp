using AssessmentEF.DataAccess.Context;
using AssessmentEF.DataAccess.Interfaces;
using AssessmentEF.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.DataAccess.Repository
{
    public class PersonnelRepository : EfBaseRepository<Personnel, EntityFrameworkDbContext>, IPersonnelRepository
    {
        public PersonnelRepository(EntityFrameworkDbContext context) : base(context)
        {
        }
        public async Task<Personnel> AddPersonnelAsync(Personnel personnel)
        {
            await Context.AddAsync(personnel);
            await Context.SaveChangesAsync();
            
            return personnel;
        }
        public async Task<Personnel> UpdatePersonnelAsync(Personnel personnel)
        {
            Context.Entry(personnel).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            var salary = new Salary
            {
                PersonnelId = personnel.ID,
                Department = personnel.Salary.Department,
                PersonnelSalary = personnel.Salary.PersonnelSalary
            };
            Context.Entry(salary).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return personnel;
        }
        public async Task<Personnel> GetPersonnelWithSalary(Expression<Func<Personnel, bool>> filter)
        {
            return await Context.Personnels.Include(x => x.Salary).FirstOrDefaultAsync(filter);
        }
    }
}
