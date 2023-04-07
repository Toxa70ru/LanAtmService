using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.customer;

namespace stall.Persistence.EntityTypeConfigurations.customer
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status", schema: "customer");
            builder.HasKey(status => status.Status_id);
            builder.HasIndex(status => status.Status_id).IsUnique();
            builder.Property(status => status.Status_name).HasMaxLength(250);
        }
    }
}
