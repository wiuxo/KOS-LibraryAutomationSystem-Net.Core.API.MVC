using KOS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOS.DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            #region Primary Key
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.RoleId).UseIdentityColumn();
            #endregion

            #region Columns
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            #endregion
        }
    }
}
