using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.UnitsOfWork;
using PikaShop.Services.Contracts;
using PikaShop.Services.Core;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Identity;

namespace PikaShop.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // DbContext Configuration & Injection
            var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(dbOptionsBuilder =>
            dbOptionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString, b => b.MigrationsAssembly("PikaShop.Data.Persistence")));

            // Identity Configuration
            builder.Services.AddIdentity<ApplicationUserEntity, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddUserManager<UserManager<ApplicationUserEntity>>()
                .AddSignInManager<SignInManager<ApplicationUserEntity>>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>();
            builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));

            // Service Injection
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
