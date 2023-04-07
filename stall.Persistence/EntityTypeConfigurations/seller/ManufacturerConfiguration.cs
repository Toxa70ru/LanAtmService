using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.seller;

namespace stall.Persistence.EntityTypeConfigurations.seller
{
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("manufacturer", schema: "seller");
            builder.HasKey(manuf => manuf.Brend_id);
            builder.HasIndex(manuf => manuf.Brend_id).IsUnique();
            builder.Property(manuf => manuf.Brend).HasMaxLength(250);
        }
    }
}
