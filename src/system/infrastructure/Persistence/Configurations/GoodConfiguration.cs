using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAdo.System.Core.Domain.Entities;

namespace ShopAdo.System.Infrastructure.Persistence.Configurations
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.Property(e => e.GoodCount).HasColumnType("numeric(18, 3)");
            builder.Property(e => e.GoodName).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Price).HasColumnType("money");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Good)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Good__CategoryId__59063A47");

            builder.HasOne(d => d.Manufacturer)
                .WithMany(p => p.Good)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__Good__Manufactur__59FA5E80");
        }
    }
}