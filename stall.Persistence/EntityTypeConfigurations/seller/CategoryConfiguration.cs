using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.seller;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace stall.Persistence.EntityTypeConfigurations.seller
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category", schema: "seller");
            builder.HasKey(category => category.Category_id);
            builder.HasIndex(category => category.Category_id).IsUnique();
            builder.Property(category => category.Category_name).HasMaxLength(250);
        }
    }
}
