using AutoMapper;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Admin.MappingProfiles
{
    public class DepartmentEntityProfile : Profile
    {
        public DepartmentEntityProfile()
        {
            CreateMap<DepartmentEntity, DepartmentViewModel>().ReverseMap();
            ShouldMapField = _ => false;
        }
    }
}
