using DeliveryService.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryService.Infrastructure.EntityTypeConfigurations
{
    public class StorehouseConfiguration : IEntityTypeConfiguration<Storehouse>
    {
        public void Configure(EntityTypeBuilder<Storehouse> builder)
        {
            builder.ToTable("storehouse", schema: "deliveryService");
            builder.HasKey(stor => stor.Storehouse_id);
            builder.HasIndex(stor => stor.Storehouse_id).IsUnique();
        }
    }
}
