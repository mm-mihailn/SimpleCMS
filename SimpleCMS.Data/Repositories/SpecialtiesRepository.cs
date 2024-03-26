using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories
{
    public class SpecialtiesRepository:Repository<Specialtie>,ISpecialtiesRepository
    {
        public SpecialtiesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Specialtie>> GetAllSpecialtiesAsync()
        {
            return await Entities.ToListAsync();
        }



        public async Task<Specialtie> GetSpecialtieById(int id)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Specialtie?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Specialtie?> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
