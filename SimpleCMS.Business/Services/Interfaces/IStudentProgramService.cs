using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface IStudentProgramService
    {
        Task<IEnumerable<StudentProgram>> GetStudentProgramAsync();
        Task<StudentProgram?> GetStudentProgramByIdAsync(int id);
        Task<StudentProgram?> GetStudentProgramByNameAsync(string name);
        Task<StudentProgram> AddSetting(StudentProgram studentProgram);
        Task<StudentProgram?> FindAsync(int id);
        Task DeleteAsync(StudentProgram setting);
        void UpdateSetting(StudentProgram studentProgram);
    }
}
