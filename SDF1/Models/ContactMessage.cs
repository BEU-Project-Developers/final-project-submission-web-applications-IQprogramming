using System.ComponentModel.DataAnnotations;

namespace SDF1.Models;

public class ContactMessage
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime SentAt { get; set; } = DateTime.Now;
}
