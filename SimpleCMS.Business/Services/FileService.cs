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
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<Files> AddFile(Files file)
        {
            return await _fileRepository.AddAsync(file);
        }

        public Task DeleteAsync(Files files)
        {
            return _fileRepository.DeleteAsync(files);
        }

        public async Task<Files> FindAsync(int id)
        {
            return await _fileRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Files>> GetFilesAsync()
        {
            return await _fileRepository.GetAllFilesAsync();
        }

        public async Task<Files?> GetFilesByIdAsync(int id)
        {
            return await _fileRepository.GetByIdAsync(id);
        }
    }
}
