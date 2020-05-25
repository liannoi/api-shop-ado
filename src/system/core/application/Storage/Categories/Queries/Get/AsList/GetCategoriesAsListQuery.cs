using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Categories.Queries.Get.AsList
{
    public class GetCategoriesAsListQuery : IRequest<CategoriesListViewModel>
    {
        public class
            GetCategoriesAsListQueryHandler : IRequestHandler<GetCategoriesAsListQuery, CategoriesListViewModel>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesAsListQueryHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoriesListViewModel> Handle(GetCategoriesAsListQuery request,
                CancellationToken cancellationToken)
            {
                return new CategoriesListViewModel
                {
                    Categories = await _context.Category
                        .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
            }
        }
    }
}