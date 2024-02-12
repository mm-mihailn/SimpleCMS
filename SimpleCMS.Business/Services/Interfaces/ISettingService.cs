using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface ISettingService
    {
        Task<IEnumerable<Setting>> GetSettingAsync();
        Task<Setting?> GetSettingByIdAsync(int id);
        Task<Setting?> GetSettingByNameAsync(string name);
        Task<Setting?> GetSettingByValueAsync(string value);

        Task<Setting> AddSetting(Setting setting);
        Task<Setting?> FindAsync(int id);
        Task DeleteAsync(Setting setting);
        void UpdateSetting(Setting setting);    
 
    }
}
