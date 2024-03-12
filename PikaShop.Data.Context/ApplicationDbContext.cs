using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Context.EntityConfigurations;

namespace PikaShop.Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration()); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=mvcProj;integrated security=true;encrypt=false");
        }

        public virtual DbSet<DepartmentEntity> Departments { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
    }
  
}
