using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Manufacturers.Queries.Get.AsList
{
    public class GetManufacturersAsListQuery : IRequest<ManufacturersListViewModel>
    {
        public class GetManufacturersAsListQueryHandler :
            IRequestHandler<GetManufacturersAsListQuery, ManufacturersListViewModel>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetManufacturersAsListQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ManufacturersListViewModel> Handle(GetManufacturersAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new ManufacturersListViewModel
                {
                    Manufacturers = await _context.Manufacturer
                        .ProjectTo<ManufacturerLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}