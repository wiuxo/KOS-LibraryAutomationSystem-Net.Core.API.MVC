using KOS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KOS.DAL;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("connectionStr"));
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}