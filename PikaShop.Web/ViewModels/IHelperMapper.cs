using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Web.ViewModels
{
    static class IHelperMapper
    {
        //public static DepartmentViewModel DepartmentMapper(DepartmentEntity entity)
        //{
        //    DepartmentViewModel department = new DepartmentViewModel()
        //    {

        //    };

        //}

        public static ProductViewModel ProductViewMapper(ProductEntity entity)
        {

            ProductViewModel ProductVM = new ProductViewModel()
            {
                Name = entity.Name,
                Id = entity.Id,
                Img = entity.Img,
                CategoryID = entity.CategoryId,
                UnitsInStock = entity.UnitsInStock,
            };
            return ProductVM;
        }

    }
}
