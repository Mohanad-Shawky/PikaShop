using AutoMapper;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Admin.MappingProfiles
{
    public class ProductSpecsEntityProfile:Profile
    {
        public ProductSpecsEntityProfile()
        {
            CreateMap<ProductSpecsEntity, ProductSpecsViewModel>().ReverseMap();
            ShouldMapField = _ => false;
        }
    }
}
