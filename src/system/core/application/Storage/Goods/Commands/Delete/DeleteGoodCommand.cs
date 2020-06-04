using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodsList;

namespace ShopAdo.System.Core.Application.Storage.Goods.Commands.Delete
{
    public class DeleteGoodCommand : IRequest<GoodDto>
    {
        public int GoodId { get; set; }

        public class DeleteGoodCommandHandler : IRequestHandler<DeleteGoodCommand, GoodDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public DeleteGoodCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodDto> Handle(DeleteGoodCommand request, CancellationToken cancellationToken)
            {
                var fined = await _context.Good
                    .Where(good => good.GoodId == request.GoodId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Good.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<GoodDto>(fined);
            }
        }
    }
}