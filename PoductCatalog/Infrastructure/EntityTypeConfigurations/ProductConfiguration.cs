using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Interfaces.Models;

namespace ProductCatalog.Infrastructure.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product", schema: "productcatalog");
            builder.HasKey(product => product.Id);
            builder.HasIndex(product => product.Id).IsUnique();
            builder.Property(product => product.Product_name).HasMaxLength(250);
            builder.Property(product => product.Description).HasMaxLength(1000);
            builder.Property(product => product.Characteristic).HasMaxLength(1000);
        }
    }
}
