using AutoMapper;
using ShopAdo.System.Core.Application.Common.Mappings;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Manufacturers
{
    public class ManufacturerLookupDto : IMapFrom<Manufacturer>
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Manufacturer, ManufacturerLookupDto>()
                .ForMember(dest => dest.ManufacturerId, opt => opt.MapFrom(s => s.ManufacturerId))
                .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(s => s.ManufacturerName));
        }
    }
}