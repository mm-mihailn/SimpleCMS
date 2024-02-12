using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<IEnumerable<Setting>> GetSettingAsync()
        {
            return await _settingRepository.GetAllSettingAsync();
        }

        public Task DeleteAsync(Setting setting)
        {
            return _settingRepository.DeleteAsync(setting);
        }

        public async Task<Setting?> GetSettingByIdAsync(int id)
        {
            return await _settingRepository.GetByIdAsync(id);
        }

        public async Task<Setting?> GetSettingByNameAsync(string name)
        {
            return await _settingRepository.GetByNameAsync(name);
        }

        public async Task<Setting> AddSetting(Setting setting)
        {
            return await _settingRepository.AddAsync(setting);
        }

        public void UpdateSetting(Setting setting)
        {
             _settingRepository.UpdateAsync(setting);
        }

        public async Task<Setting?> FindAsync(int id)
        {
            return await _settingRepository.FindAsync(id);
        }

        public async Task<Setting?> GetSettingByValueAsync(string value)
        {
            return await _settingRepository.GetByValueAsync(value);
        }
    }
}
