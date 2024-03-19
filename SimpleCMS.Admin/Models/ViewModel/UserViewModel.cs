using SimpleCMS.Data.Models;
using PagedList;
using X.PagedList.Mvc;

namespace SimpleCMS.Admin.Models.ViewModel
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
       
    }
}
