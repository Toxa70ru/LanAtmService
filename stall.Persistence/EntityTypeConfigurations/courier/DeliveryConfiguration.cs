using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.courier;

namespace stall.Persistence.EntityTypeConfigurations.courier
{
    internal class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("delivery", schema: "courier");
            builder.HasKey(deliv => deliv.Delivery_id);
            builder.HasIndex(deliv => deliv.Delivery_id).IsUnique();
        }
    }
}
