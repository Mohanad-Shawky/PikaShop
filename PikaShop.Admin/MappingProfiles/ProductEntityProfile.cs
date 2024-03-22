using AutoMapper;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Admin.MappingProfiles
{
    public class ProductEntityProfile:Profile
    {
        public ProductEntityProfile()
        {
            CreateMap<ProductEntity, ProductViewModel>().ReverseMap();
            ShouldMapField = _ => false;
        }
    }
}
