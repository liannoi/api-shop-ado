using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Core.Application.Common.Interfaces
{
    public interface IShopAdoContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Good> Good { get; set; }
        DbSet<Manufacturer> Manufacturer { get; set; }
        DbSet<Photo> Photo { get; set; }
        DbSet<Sale> Sale { get; set; }
        DbSet<SalePos> SalePos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}