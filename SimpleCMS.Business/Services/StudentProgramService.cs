using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services
{
    public class StudentProgramService : IStudentProgramService
    {
        private readonly IStudentProgramRepository _studentProgramRepository;
        public StudentProgramService(IStudentProgramRepository studentProgramRepository)
        {
            _studentProgramRepository = studentProgramRepository;
        }

        public async Task<StudentProgram> AddSetting(StudentProgram studentProgram)
        {
           return await _studentProgramRepository.AddAsync(studentProgram);
        }

        public Task DeleteAsync(StudentProgram setting)
        {
            return _studentProgramRepository.DeleteAsync(setting);
        }

        public async Task<StudentProgram?> FindAsync(int id)
        {
            return await _studentProgramRepository.FindAsync(id);
        }

        public async Task<IEnumerable<StudentProgram>> GetStudentProgramAsync()
        {
            return await _studentProgramRepository.GetAllStudentPrograms();
        }

        public async Task<StudentProgram?> GetStudentProgramByIdAsync(int id)
        {
            return await _studentProgramRepository.GetByIdAsync(id);
        }

        public async Task<StudentProgram?> GetStudentProgramByNameAsync(string name)
        {
            return await _studentProgramRepository.GetByNameAsync(name);
        }

        public void UpdateSetting(StudentProgram studentProgram)
        {
            _studentProgramRepository.UpdateAsync(studentProgram);
        }
    }
}
