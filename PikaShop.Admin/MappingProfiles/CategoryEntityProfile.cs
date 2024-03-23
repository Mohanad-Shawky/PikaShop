
using AutoMapper;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;
namespace PikaShop.Admin.MappingProfiles
{
    public class CategoryEntityProfile:Profile
    {
        public CategoryEntityProfile()
        {
            CreateMap<CategoryEntity, CategoryViewModel>()
                .ForMember<string>(cvm => cvm.DepartmentName, opt => 
                {
                    opt.MapFrom(c => c.Department != null ? c.Department.Name : "");
                    opt.NullSubstitute("");
                })
                .ReverseMap();
            ShouldMapField = _ => false;
        }
    }
}
