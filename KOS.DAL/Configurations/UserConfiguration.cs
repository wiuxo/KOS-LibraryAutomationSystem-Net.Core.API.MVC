using KOS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOS.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.UserID);
        builder.Property(x => x.UserID).UseIdentityColumn();

        #endregion

        #region Columns

        builder.Property(x => x.UserName).HasMaxLength(16).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(32).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(32).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordSalt).IsRequired();

        #endregion
    }
}