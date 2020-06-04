using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShopAdo.System.Core.Application.Common.Interfaces;
using ShopAdo.System.Core.Application.Storage.Categories;
using ShopAdo.System.Core.Application.Storage.Goods.Queries.GetGoodsList;
using ShopAdo.System.Core.Application.Storage.Manufacturers;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Storage.Goods.Commands.Create
{
    public class CreateGoodCommand : IRequest<GoodDto>
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public ManufacturerLookupDto Manufacturer { get; set; }
        public CategoryLookupDto Category { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }

        public class CreateGoodCommandHandler : IRequestHandler<CreateGoodCommand, GoodDto>
        {
            private readonly IShopAdoContext _context;
            private readonly IMapper _mapper;

            public CreateGoodCommandHandler(IShopAdoContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GoodDto> Handle(CreateGoodCommand request, CancellationToken cancellationToken)
            {
                var result = await _context.Good.AddAsync(new Good
                {
                    GoodName = request.GoodName,
                    ManufacturerId = request.Manufacturer.ManufacturerId,
                    CategoryId = request.Category.CategoryId,
                    Price = request.Price,
                    GoodCount = request.GoodCount
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<GoodDto>(result.Entity);
            }
        }
    }
}