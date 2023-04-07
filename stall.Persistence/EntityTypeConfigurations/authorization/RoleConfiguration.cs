using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.authorization;

namespace stall.Persistence.EntityTypeConfigurations.authorization
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role", schema: "authorization");
            builder.HasKey(role => role.Role_id);
            builder.HasIndex(role => role.Role_id).IsUnique();
            builder.Property(role => role.Classification).HasMaxLength(250);
        }
    }
}
