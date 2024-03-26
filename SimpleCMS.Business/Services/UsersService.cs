using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;

namespace SimpleCMS.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;

        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddAsync(user);
        }
    }
}
