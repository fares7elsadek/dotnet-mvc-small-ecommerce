using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmallEcommerceProject.Models.Data.config
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            builder.ToTable("Products");

            builder.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(p => p.Description)
                .HasColumnType("text");

            builder.Property(p => p.Price)
                .HasColumnType("decimal")
                .HasPrecision(18, 2)
                .IsRequired();

            builder.ToTable(p => p.HasCheckConstraint("CK_Price_NoNegative","[Price]>=0"));


            builder.Property(p => p.Sale)
                .HasColumnType("bit")
                .HasDefaultValue(false);


            builder.Property(p => p.Stars)
                .HasColumnType("int")
                .IsRequired();


            builder.ToTable(p => p.HasCheckConstraint("CK_Stars_isValid", "[Stars]>=1 And [Stars]<=5"));

            builder.Property(p => p.ImageUrl)
                .HasColumnType("text")
                .IsRequired();
        }
    }
}
