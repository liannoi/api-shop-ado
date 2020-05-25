using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Categories.Queries.Get
{
    public class GetCategoryQuery : IRequest<CategoryLookupDto>
    {
        public int CategoryId { get; set; }

        public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetCategoryQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryLookupDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
            {
                return await _context.Category
                    .Where(e => e.CategoryId == request.CategoryId)
                    .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}