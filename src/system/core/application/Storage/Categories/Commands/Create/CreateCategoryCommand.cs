using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CategoryLookupDto>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryLookupDto> Handle(CreateCategoryCommand request,
                CancellationToken cancellationToken)
            {
                var result = await _context.Category.AddAsync(new Category {CategoryName = request.CategoryName},
                    cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CategoryLookupDto>(result.Entity);
            }
        }
    }
}