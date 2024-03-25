using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface IStudentProgramRepository : IRepository<StudentProgram>
    {
        Task<IEnumerable<StudentProgram>> GetAllStudentPrograms();
        Task<StudentProgram> GetByIdAsync(int id);
        Task<StudentProgram> GetByNameAsync(string name);
    }
}
