using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface ISpecialtiesRepository:IRepository<Specialtie>
    {
        Task<IEnumerable<Specialtie>> GetAllSpecialtiesAsync();
        Task<Specialtie> GetSpecialtieById(int id);
        Task<Specialtie?> GetByIdAsync(int id);
        Task<Specialtie?> GetByNameAsync(string name);
    }
}
