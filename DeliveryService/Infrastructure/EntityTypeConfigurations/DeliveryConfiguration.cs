using DeliveryService.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryService.Infrastructure.EntityTypeConfigurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("delivery", schema: "deliveryService");
            builder.HasKey(deliv => deliv.Delivery_id);
            builder.HasIndex(deliv => deliv.Delivery_id).IsUnique();
        }
    }
}
