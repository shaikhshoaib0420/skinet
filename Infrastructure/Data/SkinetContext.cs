using Microsoft.EntityFrameworkCore;

public class SkinetContext : DbContext
{
    public SkinetContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}