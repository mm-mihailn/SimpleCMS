using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services
{
    public class SpecialtiesService:ISpecialtiesService
    {
        private readonly ISpecialtiesRepository _specialtieRepository;
        public SpecialtiesService(ISpecialtiesRepository specialtiesRepository)
        {
            _specialtieRepository = specialtiesRepository;
        }
        public async Task<Specialtie> AddSpecialtie(Specialtie specialtie)
        {
            return await _specialtieRepository.AddAsync(specialtie);
        }

        public async Task DeleteAsync(Specialtie specialtie)
        {
            await _specialtieRepository.DeleteAsync(specialtie);
        }
        public async Task<IEnumerable<Specialtie>> GetAllSpecialtiesAsync()
        {
            return await _specialtieRepository.GetAllSpecialtiesAsync();
        }

        public async Task<IEnumerable<Specialtie>> GetSpecialtiesAsync()
        {
            return await _specialtieRepository.GetAllSpecialtiesAsync();
        }
        public async Task UpdateSpecialtieAsync(Specialtie specialtie)
        {
            await _specialtieRepository.UpdateAsync(specialtie);
        }

        public async Task CreateSpecialtie(Specialtie specialtie)
        {
            await _specialtieRepository.AddAsync(specialtie);
        }

        public void UpdateSpecialtie(Specialtie specialtie)
        {
            _specialtieRepository.UpdateAsync(specialtie);
        }

        public async Task<Specialtie> FindAsync(int id)
        {
            return await _specialtieRepository.FindAsync(id);
        }

        public async Task<Specialtie?> GetSpecialtieByIdAsync(int id)
        {
            return await _specialtieRepository.GetByIdAsync(id);
        }
    }
}
