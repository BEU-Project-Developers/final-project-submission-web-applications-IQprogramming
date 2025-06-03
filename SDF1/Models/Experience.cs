using System.ComponentModel.DataAnnotations;

namespace SDF1.Models;

public class Experience
{
    [Key]
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
}
