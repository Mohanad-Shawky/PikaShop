using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Data.Context.EntityConfigurations.Core;
using PikaShop.Data.Context.EntityConfigurations.Identity;


namespace PikaShop.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserEntity, ApplicationUserRoleEntity, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Identity Configuration

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryPersonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemEntityConfiguration());
            #endregion

            #region Core Configuration

            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSpecsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategorySpecsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemEntityConfiguration());

            #endregion



        }

        public virtual DbSet<DepartmentEntity> Departments { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductSpecsEntity> ProductSpecs { get; set; }
        public virtual DbSet<CategorySpecsEntity> CategorySpecs { get; set; }
        public virtual DbSet<CartEntity> carts { get; set; }
        public virtual DbSet<CartItemEntity> CartItems { get; set; }
    }

}
