using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.courier;

namespace stall.Persistence.EntityTypeConfigurations.courier
{
    internal class Courier_TableConfiguration : IEntityTypeConfiguration<Courier_Table>
    {
        public void Configure(EntityTypeBuilder<Courier_Table> builder)
        {
            builder.ToTable("courier_table", schema: "courier");
            builder.HasKey(courTab => courTab.Courier_id);
            builder.HasIndex(courTab => courTab.Courier_id).IsUnique();
        }
    }
}
