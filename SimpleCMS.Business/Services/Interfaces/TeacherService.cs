using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCMS.Business.Services.Interfaces
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            return await _teacherRepository.AddAsync(teacher);
        }

        public Task DeleteAsyncTeacher(Teacher teacher)
        {
            return _teacherRepository.DeleteAsync(teacher);
        }

        public async Task<Teacher?> FindTeacherAsync(int id)
        {
            return await _teacherRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetTeacherAsync()
        {
            return await _teacherRepository.GetAllTeacherAsync();
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<Teacher?> GetTeacherByNameAsync(string name)
        {
            return await _teacherRepository.GetByNameAsync(name);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.UpdateAsync(teacher);
        }
    }
}
