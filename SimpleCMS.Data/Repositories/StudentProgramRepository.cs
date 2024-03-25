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
    public class StudentProgramRepository : Repository<StudentProgram>,IStudentProgramRepository
    {
        public StudentProgramRepository(ApplicationDbContext contex) : base(contex)
        {
            
        }

        public async Task<IEnumerable<StudentProgram>> GetAllStudentPrograms()
        {
            return await Entities.ToListAsync();
        }

        public async Task<StudentProgram> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<StudentProgram> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(p => p.SubjectName == name);
        }
    }
}
