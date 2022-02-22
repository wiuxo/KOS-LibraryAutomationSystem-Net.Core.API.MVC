using KOS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOS.DAL.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            #region
            builder.HasKey(x => x.Id);
            builder.Property(_ => _.UserID);
            builder
                .HasOne(_ => _.User)
                .WithMany(_ => _.UserRoles)
                .HasForeignKey(fk => fk.UserID)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region 
            builder.Property(_ => _.RoleId);
            builder
                .HasOne(_ => _.Role)
                .WithMany(_ => _.UserRoles)
                .HasForeignKey(fk => fk.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
