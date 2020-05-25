using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Goods.Commands.Delete
{
    public class DeleteGoodCommand : IRequest<GoodLookupDto>
    {
        public int GoodId { get; set; }

        public class DeleteGoodCommandHandler : IRequestHandler<DeleteGoodCommand, GoodLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public DeleteGoodCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodLookupDto> Handle(DeleteGoodCommand request, CancellationToken cancellationToken)
            {
                var fined = await _context.Good
                    .Where(e => e.GoodId == request.GoodId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Good.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<GoodLookupDto>(fined);
            }
        }
    }
}