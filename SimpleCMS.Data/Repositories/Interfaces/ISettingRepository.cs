using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<IEnumerable<Setting>> GetAllSettingAsync();
        Task<Setting> GetByIdAsync(int id);
        Task<Setting> GetByNameAsync(string name);


    }
}
