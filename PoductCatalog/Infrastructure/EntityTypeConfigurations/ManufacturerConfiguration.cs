using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Interfaces.Models;

namespace ProductCatalog.Infrastructure.EntityTypeConfigurations
{
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("manufacturer", schema: "productcatalog");
            builder.HasKey(manuf => manuf.Brend_id);
            builder.HasIndex(manuf => manuf.Brend_id).IsUnique();
            builder.Property(manuf => manuf.Brend).HasMaxLength(250);
        }
    }
}
