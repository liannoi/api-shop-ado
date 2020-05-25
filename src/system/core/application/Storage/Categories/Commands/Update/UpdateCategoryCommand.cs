using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;

namespace ShopAdo.System.Core.Application.Storage.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<CategoryLookupDto>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryLookupDto> Handle(UpdateCategoryCommand request,
                CancellationToken cancellationToken)
            {
                var fined = await _context.Category
                    .Where(category => category.CategoryId == request.CategoryId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.CategoryName = request.CategoryName;
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CategoryLookupDto>(fined);
            }
        }
    }
}