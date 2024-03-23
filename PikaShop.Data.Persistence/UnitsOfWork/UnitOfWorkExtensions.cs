using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.UnitsOfWork;

namespace PikaShop.Data.Persistence.UnitsOfWork
{
    public static class UnitOfWorkExtensions
    {
        public static void EnsureSeedDataForContext(this IUnitOfWork unitOfWork)
        {
            if(!unitOfWork.Departments.GetAll().Any())
            {
                // Add Departments Here

            }

            if (!unitOfWork.Categories.GetAll().Any())
            {
                // Example for Data Seeding
                // DO NOT FORGET to Link the categories to departments

                #region Categories Seeding Example
                //var categories = new List<CategoryEntity>
                //{
                //    new CategoryEntity {Name="Laptop"},
                //    new CategoryEntity {Name="TV & Audio"},
                //    new CategoryEntity {Name="Books"},
                //    new CategoryEntity {Name="Electronics"},
                //    new CategoryEntity {Name="Womens Fashion"},
                //    new CategoryEntity {Name="Mens Fashion"},
                //    new CategoryEntity {Name="Health & Household'"},
                //    new CategoryEntity {Name="Home & Kitchen"},
                //    new CategoryEntity {Name="Sports & Outdoors"},
                //    new CategoryEntity {Name="Tools & Home Improvement"},
                //    new CategoryEntity {Name="Toys & Games"}
                //};
                //unitOfWork.Categories.CreateRange(categories);
                //unitOfWork.Save();
                #endregion
            }

            if (!unitOfWork.Products.GetAll().Any())
            {

                // >>>>Can NOT Add Products without Categories first!!!!!!<<<<<

            //    List<ProductEntity> products =
            //    [
            // new ProductEntity { Name = "Sharp 4K TV", Description = "Ultra HD 4K Smart TV", Price = 599.99, UnitsInStock = 50, CategoryID = 1 },
            //new ProductEntity { Name = "Samsung Quantum Dot OLED", Description = "Quantum Dot OLED Smart TV", Price = 799.99, UnitsInStock = 45, CategoryID = 1 },
            //new ProductEntity { Name = "Sony 8K TV", Description = "8K HDR Smart TV", Price = 1999.99, UnitsInStock = 20, CategoryID = 1 },
            //new ProductEntity { Name = "LG NanoCell TV", Description = "NanoCell 4K HDR Smart TV", Price = 899.99, UnitsInStock = 35, CategoryID = 1 },
            //new ProductEntity { Name = "Toshiba Fire TV", Description = "Fire TV Edition Smart TV", Price = 499.99, UnitsInStock = 40, CategoryID = 1 },
            //new ProductEntity { Name = "HP Laptop d439", Description = "HP 14-Inch Laptop", Price = 699.99, UnitsInStock = 30, CategoryID = 2 },
            //new ProductEntity { Name = "HP Omen 17", Description = "HP Omen 17-Inch Gaming Laptop", Price = 1299.99, UnitsInStock = 20, CategoryID = 2 },
            //new ProductEntity { Name = "Alienware 18", Description = "Alienware 18-Inch Gaming Laptop", Price = 1899.99, UnitsInStock = 25, CategoryID = 2 },
            //new ProductEntity { Name = "Dell XPS 15", Description = "Dell XPS 15-Inch Laptop", Price = 1399.99, UnitsInStock = 15, CategoryID = 2 },
            //new ProductEntity { Name = "Lenovo ThinkPad X1 Carbon", Description = "Lenovo ThinkPad X1 Carbon 14-Inch Laptop", Price = 1499.99, UnitsInStock = 10, CategoryID = 2 }
            //    ];

            //    unitOfWork.Products.CreateRange(products);
            //    unitOfWork.Save();
            }
        }
    }
}
