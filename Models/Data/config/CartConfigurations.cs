using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
namespace SmallEcommerceProject.Models.Data.config
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.TotalPrice)
                .HasColumnType("decimal")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.ToTable(p => p.HasCheckConstraint("CK_TotalPrice_NoNegative", "[TotalPrice]>=0"));

            builder.HasMany(p => p.Products)
                .WithOne(p => p.Cart)
                .HasForeignKey(c => c.Cart_Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
