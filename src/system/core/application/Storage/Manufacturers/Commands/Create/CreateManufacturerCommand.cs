using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Manufacturers.Commands.Create
{
    public class CreateManufacturerCommand : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public class CreateManufacturerCommandHandler :
            IRequestHandler<CreateManufacturerCommand, ManufacturerLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public CreateManufacturerCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(CreateManufacturerCommand request,
                CancellationToken cancellationToken)
            {
                var result =
                    await _context.Manufacturer.AddAsync(new Manufacturer {ManufacturerName = request.ManufacturerName},
                        cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ManufacturerLookupDto>(result.Entity);
            }
        }
    }
}