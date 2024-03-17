using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.UnitsOfWork;
using PikaShop.Services.Contracts;
using PikaShop.Services.Core;
using PikaShop.Data.Context.ContextEntities.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Protocols;
using PikaShop.Data.Context;
using PikaShop.Web.IdentityUnits;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Google;
using System.Configuration;

namespace PikaShop.Web
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region DbContext Configuration
            // DbContext Configuration & Injection
            var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection") ?? throw new InvalidOperationException("Connection string 'DevelopmentConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(dbOptionsBuilder =>
            dbOptionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString, b => b.MigrationsAssembly("PikaShop.Web")));
            #endregion

            #region Identity Configuration
            // Identity Configuration
            builder.Services.AddIdentity<ApplicationUserEntity, ApplicationUserRoleEntity>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager<ApplicationUserEntity>>()
                .AddSignInManager<SignInManager<ApplicationUserEntity>>()
                .AddRoleManager<RoleManager<ApplicationUserRoleEntity>>().AddDefaultUI().AddDefaultTokenProviders();//.AddUserConfirmation<ApplicationUserEntity>();
            builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));
            #endregion

            #region External Logins
            builder.Services.AddAuthentication()
            .AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
            }).AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            }).AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
            }); 
            #endregion

            #region Custom Service Configuration
            // Service Injection
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<UserManager<ApplicationUserEntity>>();
            builder.Services.AddScoped<RoleManager<ApplicationUserRoleEntity>>();


            #endregion

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // MVC Configuration
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<IProductRepository,ProductRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();

                    //DbRoleSeeder.SeedRolesAndAdminAsync();
                    // Seed Database for Development
                    ApplicationDbContextFactory contextFactory = new ApplicationDbContextFactory();
                UnitOfWork unitOfWork = new UnitOfWork(contextFactory.CreateDbContext([""]));
                unitOfWork.EnsureSeedDataForContext();
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
            name: "profile1",
            pattern: "{area}/{controller}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();


            using (var scope = app.Services.CreateScope())
                await DbRoleSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);


            app.Run();
        }
    }
}
