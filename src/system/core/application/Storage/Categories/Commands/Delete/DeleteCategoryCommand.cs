using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<CategoryLookupDto>
    {
        public int CategoryId { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryLookupDto> Handle(DeleteCategoryCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Category
                    .Where(e => e.CategoryId == request.CategoryId)
                    .FirstOrDefaultAsync(cancellationToken);

                _context.Category.Remove(fined);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CategoryLookupDto>(fined);
            }
        }
    }
}