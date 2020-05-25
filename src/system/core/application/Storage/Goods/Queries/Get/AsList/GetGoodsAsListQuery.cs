using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Goods.Queries.Get.AsList
{
    public class GetGoodsAsListQuery : IRequest<GoodsListViewModel>
    {
        public class GetGoodsAsListQueryHandler : IRequestHandler<GetGoodsAsListQuery, GoodsListViewModel>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetGoodsAsListQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodsListViewModel> Handle(GetGoodsAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new GoodsListViewModel
                {
                    Goods = await _context.Good
                        .ProjectTo<GoodLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}