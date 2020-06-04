using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodDetail;

namespace ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodsList
{
    public class GetGoodsListQuery : IRequest<GoodsListViewModel>
    {
        public class GetGoodsAsListQueryHandler : IRequestHandler<GetGoodsListQuery, GoodsListViewModel>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetGoodsAsListQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodsListViewModel> Handle(GetGoodsListQuery request,
                CancellationToken cancellationToken)
            {
                return new GoodsListViewModel
                {
                    Goods = await _context.Good
                        .ProjectTo<GoodDetailViewModel>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}