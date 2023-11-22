using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SimpleCMS.Data.Models
{
    public class User : IdentityUser
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
    }
}
