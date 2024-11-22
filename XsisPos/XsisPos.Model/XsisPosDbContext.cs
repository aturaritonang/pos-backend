using Microsoft.EntityFrameworkCore;

namespace XsisPos.Model
{
    public class XsisPosDbContext: DbContext
    {
        public XsisPosDbContext(DbContextOptions<XsisPosDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
