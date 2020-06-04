using System.Collections.Generic;
using AutoMapper;
using ShopAdo.System.Core.Application.Common.Mappings;
using ShopAdo.System.Core.Application.Storage.Categories;
using ShopAdo.System.Core.Application.Storage.Manufacturers;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodDetail
{
    public class GoodDetailViewModel : IMapFrom<Good>
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public ManufacturerLookupDto Manufacturer { get; set; }
        public CategoryLookupDto Category { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }

        public IEnumerable<GoodPhotoDto> Photos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Good, GoodDetailViewModel>()
                .ForMember(dest => dest.GoodId, opt => opt.MapFrom(s => s.GoodId))
                .ForMember(dest => dest.GoodName, opt => opt.MapFrom(s => s.GoodName))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(s => s.Category))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(dest => dest.GoodCount, opt => opt.MapFrom(s => s.GoodCount))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(s => s.Photo));
        }
    }
}