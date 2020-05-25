using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Infrastructure.Persistence.Configurations
{
    public class SalePosConfiguration : IEntityTypeConfiguration<SalePos>
    {
        public void Configure(EntityTypeBuilder<SalePos> builder)
        {
            builder.Property(e => e.GoodCount).HasDefaultValueSql("((1))");
            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

            builder.HasOne(d => d.Good)
                .WithMany(p => p.SalePos)
                .HasForeignKey(d => d.GoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalePos__GoodId__5BE2A6F2");

            builder.HasOne(d => d.Sale)
                .WithMany(p => p.SalePos)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalePos__SaleId__5CD6CB2B");
        }
    }
}