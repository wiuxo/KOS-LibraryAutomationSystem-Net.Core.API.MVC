namespace KOS.Entities.Models;

public class Book : IEntity
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public string Subject { get; set; }
    public int? HoldStatus { get; set; }
    public int? BorrowerID { get; set; }
    public int IsRemoved { get; set; }
    public int ReturnedOnHold { get; set; }
}