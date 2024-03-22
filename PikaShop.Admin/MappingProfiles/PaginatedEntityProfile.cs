using AutoMapper;
using PikaShop.Admin.Helpers.Pagination;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;

namespace PikaShop.Admin.MappingProfiles
{
    public class PaginatedEntityProfile : Profile

    {
        public PaginatedEntityProfile()
        {
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
        }
    }
}
