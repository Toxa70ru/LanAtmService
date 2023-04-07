using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.customer;

namespace stall.Persistence.EntityTypeConfigurations.customer
{
    internal class Customer_TableConfiguration : IEntityTypeConfiguration<Customer_Table>
    {
        public void Configure(EntityTypeBuilder<Customer_Table> builder)
        {
            builder.ToTable("customer_table", schema: "customer");
            builder.HasKey(custab => custab.Customer_id);
            builder.HasIndex(custab => custab.Customer_id).IsUnique();
        }
    }
}
