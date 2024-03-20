using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Web.ViewModels
{
    static class IHelperMapper
    {
        public static ProductViewModel ProductViewMapper(ProductEntity entity)
        {
            ProductViewModel ProductVM = new()
            {
                Name = entity.Name,
                Id = entity.ID,
                Img = entity.Img,
                CategoryID = entity.CategoryID,
                UnitsInStock = entity.UnitsInStock,
            };
            return ProductVM;
        }
    }
}
