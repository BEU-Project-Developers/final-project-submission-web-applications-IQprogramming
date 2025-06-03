using System.ComponentModel.DataAnnotations;

namespace SDF1.Models;

public class Review
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; } // 1-5 arası
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}
