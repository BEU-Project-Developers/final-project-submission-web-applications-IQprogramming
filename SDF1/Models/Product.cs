using System.ComponentModel.DataAnnotations;

namespace SDF1.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
}
