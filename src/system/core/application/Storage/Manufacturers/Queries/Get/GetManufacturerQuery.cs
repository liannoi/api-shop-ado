using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Manufacturers.Queries.Get
{
    public class GetManufacturerQuery : IRequest<ManufacturerLookupDto>
    {
        public int ManufacturerId { get; set; }

        public class GetManufacturerQueryHandler : IRequestHandler<GetManufacturerQuery, ManufacturerLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetManufacturerQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturerLookupDto> Handle(GetManufacturerQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Manufacturer
                    .Where(man => man.ManufacturerId == request.ManufacturerId)
                    .ProjectTo<ManufacturerLookupDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}