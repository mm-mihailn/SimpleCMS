using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface IFileService
    {
        Task<Files> AddFile(Files file);
        Task<IEnumerable<Files>> GetFilesAsync();
        Task<Files?> GetFilesByIdAsync(int id);
        Task<Files> FindAsync(int id);
        Task DeleteAsync(Files files);
    }
}
