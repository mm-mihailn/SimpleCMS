using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Admin.Data
{
    public class SimpleCMSAdminContext : DbContext
    {
        public SimpleCMSAdminContext (DbContextOptions<SimpleCMSAdminContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleCMS.Data.Models.Article> Article { get; set; } = default!;
    }
}
