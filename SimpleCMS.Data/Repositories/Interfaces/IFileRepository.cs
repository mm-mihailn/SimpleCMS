using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface IFileRepository : IRepository<Files>
    {
        Task<IEnumerable<Files>> GetAllFilesAsync();
        Task<Files> GetByIdAsync(int id);
    }
}
