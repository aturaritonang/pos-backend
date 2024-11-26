using Microsoft.EntityFrameworkCore;

namespace XsisPos.Model
{
    public class XsisPosDbContext : DbContext
    {
        public XsisPosDbContext(DbContextOptions<XsisPosDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(o => o.Initial)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasIndex(o => o.Initial)
                    .IsUnique();

                entity.Property(o => o.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(o => o.Name)
                    .IsUnique();

                entity.Property(o => o.Description)
                    .IsRequired(false);

                entity.Property(o => o.Active)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(o => o.CategoryId)
                    .IsRequired();

                entity.Property(o => o.Initial)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasIndex(o => o.Initial)
                    .IsUnique();

                entity.Property(o => o.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(o => o.Name)
                    .IsUnique();

                entity.Property(o => o.Description)
                    .IsRequired(false);

                entity.Property(o => o.Active)
                    .HasDefaultValue(false);

            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.Property(o => o.ProductId)
                    .IsRequired();

                entity.Property(o => o.Initial)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasIndex(o => o.Initial)
                    .IsUnique();

                entity.Property(o => o.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(o => o.Name)
                    .IsUnique();

                entity.Property(o => o.Description)
                    .IsRequired(false);

                entity.Property(o => o.Active)
                    .HasDefaultValue(false);

            });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=localhost,1433; Database=XsisPosDb; User Id=sa; Password=password#");
        //}
    }
}
