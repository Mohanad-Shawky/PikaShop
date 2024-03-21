
using AutoMapper;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;
namespace PikaShop.Admin.MappingProfiles
{
    public class CategoryEntityProfile:Profile
    {
        public CategoryEntityProfile()
        {
            CreateMap<CategoryEntity, CategoryViewModel>().ReverseMap();
            ShouldMapField = _ => false;
        }
    }
}
