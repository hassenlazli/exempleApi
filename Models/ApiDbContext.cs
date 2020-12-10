using Microsoft.EntityFrameworkCore;

namespace exempleApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)

        { }

        public DbSet<Produit> Produits { get; set; }
    }
}
