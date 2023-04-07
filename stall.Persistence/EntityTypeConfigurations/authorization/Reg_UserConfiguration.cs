using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using stall.Domain.authorization;

namespace stall.Persistence.EntityTypeConfigurations.authorization
{
    internal class Reg_UserConfiguration : IEntityTypeConfiguration<Reg_User>
    {
        public void Configure(EntityTypeBuilder<Reg_User> builder)
        {
            builder.ToTable("reg_user", schema: "authorization");
            builder.HasKey(Ruser => Ruser.User_id);
            builder.HasIndex(Ruser => Ruser.User_id).IsUnique();

            builder.Property(Ruser => Ruser.Surname).HasMaxLength(250);
            builder.Property(Ruser => Ruser.Name).HasMaxLength(250);
            builder.Property(Ruser => Ruser.Midlename).HasMaxLength(250);
            builder.Property(Ruser => Ruser.Phone_Number).HasMaxLength(11);

            builder.Property(Ruser => Ruser.Login).HasMaxLength(60);
            builder.HasIndex(Ruser => Ruser.Login).IsUnique();

            builder.Property(Ruser => Ruser.Password).HasMaxLength(60);
            builder.HasIndex(Ruser => Ruser.Password).IsUnique();

        }
    }
}
