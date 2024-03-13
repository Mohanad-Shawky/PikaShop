using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Context.EntityConfigurations;

namespace PikaShop.Data.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }

        public virtual DbSet<DepartmentEntity> Departments { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
    }

}
