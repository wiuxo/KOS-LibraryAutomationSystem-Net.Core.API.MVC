using KOS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KOS.DAL.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.BookID);
        builder.Property(x => x.BookID).UseIdentityColumn();

        #endregion

        #region Columns

        builder.Property(x => x.Title).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Author).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Genre).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Subject).HasMaxLength(64).IsRequired();

        #endregion
    }
}