using System.ComponentModel.DataAnnotations;

namespace SDF1.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    // Optional relation
    public virtual ICollection<Product> Products { get; set; }
}
