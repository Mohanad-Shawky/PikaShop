using AutoMapper;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Admin.MappingProfiles
{
    public class CategorySpecsEntityProfile:Profile
    {
        public CategorySpecsEntityProfile()
        {
            CreateMap<CategorySpecsEntity, CategorySpecsViewModel>().ReverseMap();
            ShouldMapField = _ => false;
        }
    }
}
