using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Manufacturers.Commands.Delete
{
    public class DeleteManufacturerCommand : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }

        public class DeleteManufacturerCommandHandler :
            IRequestHandler<DeleteManufacturerCommand, ManufacturerLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public DeleteManufacturerCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(DeleteManufacturerCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturer
                    .Where(manufacturer => manufacturer.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Manufacturer.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ManufacturerLookupDto>(fined);
            }
        }
    }
}