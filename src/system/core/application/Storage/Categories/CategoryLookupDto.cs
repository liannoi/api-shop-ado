using AutoMapper;
using ShopAdo.System.Core.Application.Common.Mappings;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Categories
{
    public class CategoryLookupDto : IMapFrom<Category>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookupDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(s => s.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(s => s.CategoryName));
        }
    }
}