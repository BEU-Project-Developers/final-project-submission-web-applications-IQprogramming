using Microsoft.AspNetCore.Identity;

namespace SDF1.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}
