using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SDF1.Models;

namespace SDF1.Data
{
    public class KellyContext : IdentityDbContext<AppUser>
    {
        public KellyContext(DbContextOptions<KellyContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Experience> Experiences { get; set; }

    }
}
