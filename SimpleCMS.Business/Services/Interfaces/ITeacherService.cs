using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetTeacherAsync();
        Task<Teacher?> GetTeacherByIdAsync(int id);
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher?> GetTeacherByNameAsync(string name);
        Task DeleteAsyncTeacher(Teacher teacher);
        Task<Teacher?> FindTeacherAsync(int id);
        void UpdateTeacher(Teacher teacher);
    }
}
