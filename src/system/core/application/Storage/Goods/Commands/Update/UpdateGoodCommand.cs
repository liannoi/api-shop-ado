using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Application.Storage.Categories;
using ShopAdo.System.Core.Application.Storage.Manufacturers;

namespace ShopAdo.System.Core.Application.Storage.Goods.Commands.Update
{
    public class UpdateGoodCommand : IRequest<GoodLookupDto>
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public ManufacturerLookupDto Manufacturer { get; set; }
        public CategoryLookupDto Category { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }

        public class UpdateGoodCommandHandler : IRequestHandler<UpdateGoodCommand, GoodLookupDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public UpdateGoodCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodLookupDto> Handle(UpdateGoodCommand request, CancellationToken cancellationToken)
            {
                var fined = await _context.Good
                    .Where(e => e.GoodId == request.GoodId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.GoodName = request.GoodName;

                fined.Manufacturer = await _context.Manufacturer
                    .Where(e => e.ManufacturerId == request.Manufacturer.ManufacturerId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Category = await _context.Category
                    .Where(e => e.CategoryId == request.Category.CategoryId)
                    .FirstOrDefaultAsync(cancellationToken);

                fined.Price = request.Price;
                fined.GoodCount = request.GoodCount;
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<GoodLookupDto>(fined);
            }
        }
    }
}