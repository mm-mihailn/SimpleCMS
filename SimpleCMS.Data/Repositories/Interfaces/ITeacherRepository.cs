using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetByIdAsyncNoTracking(int id);
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> GetByNameAsync(string name);
    }
}
