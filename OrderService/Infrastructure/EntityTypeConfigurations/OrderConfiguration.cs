using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Interfaces.models;

namespace OrderService.Infrastructure
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order", schema: "orderService");
            builder.HasKey(order => order.Order_id);
            builder.HasIndex(order => order.Order_id).IsUnique();
            builder.Property(order => order.Full_name).HasMaxLength(250);
            builder.Property(order => order.Adres).HasMaxLength(250);
        }
    }
}
