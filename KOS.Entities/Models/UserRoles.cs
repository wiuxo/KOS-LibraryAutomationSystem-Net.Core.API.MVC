namespace KOS.Entities.Models
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
