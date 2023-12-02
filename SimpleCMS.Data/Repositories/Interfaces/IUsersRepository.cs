using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface IUsersRepository :IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User?> GetByIdAsync(string id);

        Task<User?> GetByEmailAsync(string email);

        Task<int> GetCountAllAsync();

    }
}
