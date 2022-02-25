using System.Collections.ObjectModel;

namespace KOS.Entities.Models;

public class Role : IEntity
{
    public int RoleId { get; set; }

    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
}