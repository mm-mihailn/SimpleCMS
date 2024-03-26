﻿using Microsoft.AspNetCore.Identity;
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
        public DbSet<Specialtie> Specialties => Set<Specialtie>();
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
                Title = "Профил на куповача",
                Published = true
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

           // var adminUserId = Guid.NewGuid().ToString();
            //var user = new User
            //{
            //    //Id = adminUserId,
            //    UserName = email,
            //    NormalizedUserName = email.ToUpper(),
            //    Email = email,
            //    NormalizedEmail = email.ToUpper(),
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    PhoneNumber = "1234567890",
            //    Name = "John Smith"
            //};
            //var passwordHasher = new PasswordHasher<User>();
            //user.PasswordHash = passwordHasher.HashPassword(user, "!w@ntT0L0g!n");
            //builder.Entity<User>().HasData(user);

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