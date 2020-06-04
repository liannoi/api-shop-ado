using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Application.Storage.Categories;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodsList;
using ShopAdo.System.Core.Application.Storage.Manufacturers;

namespace ShopAdo.System.Core.Application.Storage.Goods.Commands.Update
{
    public class UpdateGoodCommand : IRequest<GoodDto>
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public ManufacturerLookupDto Manufacturer { get; set; }
        public CategoryLookupDto Category { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }

        public class UpdateGoodCommandHandler : IRequestHandler<UpdateGoodCommand, GoodDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public UpdateGoodCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodDto> Handle(UpdateGoodCommand request, CancellationToken cancellationToken)
            {
                var fined = await _context.Good
                    .Where(good => good.GoodId == request.GoodId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Manufacturer = await _context.Manufacturer
                    .Where(manufacturer => manufacturer.ManufacturerId == request.Manufacturer.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Category = await _context.Category
                    .Where(category => category.CategoryId == request.Category.CategoryId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.GoodName = request.GoodName;
                fined.Price = request.Price;
                fined.GoodCount = request.GoodCount;
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<GoodDto>(fined);
            }
        }
    }
}