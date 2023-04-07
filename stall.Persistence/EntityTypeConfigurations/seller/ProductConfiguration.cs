using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.seller;

namespace stall.Persistence.EntityTypeConfigurations.seller
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product", schema: "seller");
            builder.HasKey(product => product.Product_id);
            builder.HasIndex(product => product.Product_id).IsUnique();
            builder.Property(product => product.Product_name).HasMaxLength(250);
            builder.Property(product => product.Description).HasMaxLength(1000);
            builder.Property(product => product.Characteristic).HasMaxLength(1000);
        }
    }
}
