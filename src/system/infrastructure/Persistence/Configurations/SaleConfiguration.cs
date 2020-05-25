using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Infrastructure.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(e => e.HireDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(e => e.UserId).HasDefaultValueSql("((1))");
        }
    }
}