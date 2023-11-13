using AssessmentEF.Business.Abstract;
using AssessmentEF.DataAccess.Interfaces;
using AssessmentEF.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.Business.Concrate
{
    public class PersonnelManager : IPersonnelService
    {
        private readonly IPersonnelRepository _personnelRepository;

        public PersonnelManager(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public async Task<Personnel> AddAsync(Personnel model)
        {
            return await _personnelRepository.AddPersonnelAsync(model);
        }

        public async Task<int> CountAsync()
        {
            return await _personnelRepository.CountAsync();
        }

        public async Task<Personnel> DeleteAsync(Personnel model)
        {
            return await _personnelRepository.DeleteAsync(model);
        }

        public async Task<Personnel> GetPersonnelByIdAsync(int id)
        {
            return await _personnelRepository.GetPersonnelWithSalary(p => p.ID == id);
        }

        public async Task<IReadOnlyList<Personnel>> ListAllAsync()
        {
            return await _personnelRepository.ListAllAsync();
        }

        public async Task<IReadOnlyList<Personnel>> ListAsync(Expression<Func<Personnel, bool>> filter)
        {
            return await _personnelRepository.ListAllAsync(filter);
        }

        public async Task<Personnel> UpdateAsync(Personnel model)
        {
            return await _personnelRepository.UpdatePersonnelAsync(model);
        }
    }
}
