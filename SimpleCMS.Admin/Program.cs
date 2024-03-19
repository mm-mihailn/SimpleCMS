using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Business.Services;
using SimpleCMS.Data;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories;
using SimpleCMS.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IMenuItemsRepository, MenuItemsRepository>();
builder.Services.AddScoped<IMenuItemsService,MenuItemService>();

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<ISettingService, SettingService>();

builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();
builder.Services.AddScoped<IArticlesService, ArticlesService>();

builder.Services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
builder.Services.AddScoped<ISpecialtiesService, SpecialtiesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
