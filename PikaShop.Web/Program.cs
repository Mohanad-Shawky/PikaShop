using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.Repositories;
using PikaShop.Data.Persistence.UnitsOfWork;
using PikaShop.Services.Core;
using PikaShop.Services.Contracts;
using PikaShop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace PikaShop.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(dbOptionsBuilder =>
            dbOptionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration
            .GetConnectionString("DevelopmentConnection"), b => b.MigrationsAssembly("PikaShop.Data.Persistence")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
