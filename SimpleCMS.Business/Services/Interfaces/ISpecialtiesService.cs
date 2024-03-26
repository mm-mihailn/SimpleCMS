using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface ISpecialtiesService
    {
        Task<IEnumerable<Specialtie>> GetSpecialtiesAsync();
        Task DeleteAsync(Specialtie specialtie);
        void UpdateSpecialtie(Specialtie specialtie);
        Task<Specialtie> FindAsync(int id);
        Task<IEnumerable<Specialtie>> GetAllSpecialtiesAsync();
        Task<Specialtie> AddSpecialtie(Specialtie specialtie);
        Task<Specialtie?> GetSpecialtieByIdAsync(int id);
        Task CreateSpecialtie(Specialtie specialtie);
        Task UpdateSpecialtieAsync(Specialtie specialtie);
    }
}
