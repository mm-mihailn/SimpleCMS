using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data.EntityConfigurations;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Files> Files => Set<Files>();

        public DbSet<Setting> Setting => Set<Setting>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Rename Identity tables
            builder.Entity<IdentityRole>().ToTable(name: "Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MenuItemConfiguration());
            builder.ApplyConfiguration(new ArticleConfigurations());
            builder.ApplyConfiguration(new FileConfigurations());
            builder.ApplyConfiguration(new SettingConfigurations());

            SeedInitialData(builder);
        }

        private void SeedInitialData(ModelBuilder builder)
        {
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 1,
                Link = "test",
                Title = "Училище",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 2,
                Link = "test",
                Title = "Начало",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 3,
                Link = "test",
                Title = "Прием",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 4,
                Link = "test",
                Title = "За Родителя",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 5,
                Link = "test",
                Title = "За Ученика",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 6,
                Link = "test",
                Title = "Контакти",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 7,
                Link = "test",
                Title = "Галерия",
                Published = true
            });

            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 8,
                Link = "test",
                Title = "Профил на купувача",
                Published = true
            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 9,
                Link = "test",
                Title = "Административни услуги",
                Published = true,
                ParentId=1
                
            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 10,
                Link = "test",
                Title = "Учителски състав",
                Published = true,
                ParentId = 1

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 11,
                Link = "test",
                Title = "История",
                Published = true,
                ParentId = 1

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 12,
                Link = "test",
                Title = "Новини",
                Published = true,
                ParentId = 1

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 13,
                Link = "test",
                Title = "Партньори и проекти",
                Published = true,
                ParentId = 1

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 14,
                Link = "test",
                Title = "Брошура",
                Published = true,
                ParentId = 3

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 15,
                Link = "test",
                Title = "Специалности",
                Published = true,
                ParentId = 3

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 16,
                Link = "test",
                Title = "Приложно програмиране",
                Published = true,
                ParentId = 15

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 17,
                Link = "test",
                Title = "КТТ",
                Published = true,
                ParentId = 15

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 18,
                Link = "test",
                Title = "Електроенергетика",
                Published = true,
                ParentId = 15

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 19,
                Link = "test",
                Title = "Електрообзавеждане",
                Published = true,
                ParentId = 15

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 20,
                Link = "test",
                Title = "Роботика",
                Published = true,
                ParentId = 15

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 21,
                Link = "test",
                Title = "Стипендии",
                Published = true,
                ParentId = 4

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 22,
                Link = "test",
                Title = "Ел. Дневник",
                Published = true,
                ParentId = 4

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 23,
                Link = "test",
                Title = "Изпити",
                Published = true,
                ParentId = 5

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 24,
                Link = "test",
                Title = "Учебници",
                Published = true,
                ParentId = 5

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 25,
                Link = "test",
                Title = "Седмично разписание",
                Published = true,
                ParentId = 5

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 26,
                Link = "test",
                Title = "ДЗИ",
                Published = true,
                ParentId = 23

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 27,
                Link = "test",
                Title = "Поправителни изпити",
                Published = true,
                ParentId = 23

            });
            builder.Entity<MenuItem>().HasData(new MenuItem()
            {
                Id = 28,
                Link = "test",
                Title = "Самостоятелна форма",
                Published = true,
                ParentId = 23

            });
            // Seed user roles and users
            var roleName = "Administrator";
            var adminRoleId = Guid.NewGuid().ToString();
            var adminUserId = Guid.NewGuid().ToString();

            // Seed identity role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            });

            // Seed user
            var email = "admin@simplecms.net";
            var user = new User
            {
                //Id = adminUserId,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                Name = "John Smith"
            };
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "!w@ntT0L0g!n");

            builder.Entity<User>().HasData(user);

            // Seed identity user role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                }
            
            );
        }
    }
   
}