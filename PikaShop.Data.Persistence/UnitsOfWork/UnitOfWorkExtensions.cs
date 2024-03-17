using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if(!unitOfWork.Products.GetAll().Any())
            {
                // Add Products Here
            }
        }
    }
}
