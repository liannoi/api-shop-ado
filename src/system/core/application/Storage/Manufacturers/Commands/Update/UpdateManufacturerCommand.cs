using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Manufacturers.Commands.Update
{
    public class UpdateManufacturerCommand : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public class UpdateManufacturerCommandHandler :
            IRequestHandler<UpdateManufacturerCommand, ManufacturerLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public UpdateManufacturerCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(UpdateManufacturerCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Manufacturer
                    .Where(manufacturer => manufacturer.ManufacturerId == request.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.ManufacturerName = request.ManufacturerName;
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ManufacturerLookupDto>(fined);
            }
        }
    }
}