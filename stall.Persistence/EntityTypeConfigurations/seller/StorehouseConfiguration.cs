using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.seller;

namespace stall.Persistence.EntityTypeConfigurations.seller
{
    internal class StorehouseConfiguration : IEntityTypeConfiguration<Storehouse>
    {
        public void Configure(EntityTypeBuilder<Storehouse> builder)
        {
            builder.ToTable("storehouse", schema: "seller");
            builder.HasKey(stor => stor.Storehouse_id);
            builder.HasIndex(stor => stor.Storehouse_id).IsUnique();
        }
    }

}
