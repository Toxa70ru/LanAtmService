using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.customer;

namespace stall.Persistence.EntityTypeConfigurations.customer
{
    internal class Order_PickingConfiguration : IEntityTypeConfiguration<Order_Picking>
    {
        public void Configure(EntityTypeBuilder<Order_Picking> builder)
        {
            builder.ToTable("order_picking", schema: "customer");
            builder.HasKey(orderP => orderP.Chek_id);
            builder.HasIndex(orderP => orderP.Chek_id).IsUnique();
        }
    }
}
