using AutoMapper;
using ShopAdo.System.Core.Application.Common.Mappings;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodDetail
{
    public class GoodPhotoDto : IMapFrom<Photo>
    {
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Photo, GoodPhotoDto>()
                .ForMember(dest => dest.PhotoId, opt => opt.MapFrom(s => s.PhotoId))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(s => s.PhotoPath));
        }
    }
}