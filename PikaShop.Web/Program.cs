using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.Repositories;
using PikaShop.Data.Persistence.UnitsOfWork;

namespace PikaShop.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

<<<<<<< Updated upstream
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<IProductRepository,ProductRepository>();
          builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();
=======
            //injection of services inside Controller

            //builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            //builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            //builder.Services.AddScoped<IProductServices, ProductServices>();

                var app = builder.Build();
>>>>>>> Stashed changes

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
