using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace KOS.Entities.Models;

public class User : IEntity
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    [JsonIgnore] public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();

    [JsonIgnore] public byte[] PasswordHash { get; set; }
    [JsonIgnore] public byte[] PasswordSalt { get; set; }
}