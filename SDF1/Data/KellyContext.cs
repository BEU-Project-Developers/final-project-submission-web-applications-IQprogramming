using Microsoft.EntityFrameworkCore;

namespace SDF1.Data;

public class KellyContext(DbContextOptions<KellyContext> options) : DbContext(options)
{
    
}