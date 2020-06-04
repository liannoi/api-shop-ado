using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodDetail
{
    public class GetGoodDetailQuery : IRequest<GoodDetailViewModel>
    {
        public int GoodId { get; set; }

        public class GetGoodQueryHandler : IRequestHandler<GetGoodDetailQuery, GoodDetailViewModel>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetGoodQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodDetailViewModel> Handle(GetGoodDetailQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Good
                    .Where(e => e.GoodId == request.GoodId)
                    .ProjectTo<GoodDetailViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}