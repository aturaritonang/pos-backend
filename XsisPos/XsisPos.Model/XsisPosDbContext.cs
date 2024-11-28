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
            modelBuilder.Seed();

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
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category() { Id = 1, Initial = "Food", Name = "Food", Description = "High quality food", Active = true, Created = DateTime.UtcNow },
                    new Category() { Id = 2, Initial = "Beverage", Name = "Beverage", Description = "High quality beverage", Active = true, Created = DateTime.UtcNow },
                    new Category() { Id = 3, Initial = "Dessert", Name = "Dessert", Description = "High quality dessert", Active = true, Created = DateTime.UtcNow }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { Id = 1, CategoryId = 1, Initial = "Rice", Name = "Rice", Description = "High quality rice", Active = true, Created = DateTime.UtcNow },
                    new Product() { Id = 2, CategoryId = 1, Initial = "Pizza", Name = "Pizza", Description = "High quality pizza", Active = true, Created = DateTime.UtcNow },
                    new Product() { Id = 3, CategoryId = 2, Initial = "Coffee", Name = "Coffee", Description = "High quality coffee", Active = true, Created = DateTime.UtcNow },
                    new Product() { Id = 4, CategoryId = 2, Initial = "Juice", Name = "Juice", Description = "High quality juice", Active = true, Created = DateTime.UtcNow },
                    new Product() { Id = 5, CategoryId = 3, Initial = "Pudding", Name = "Pudding", Description = "High quality pudding", Active = true, Created = DateTime.UtcNow },
                    new Product() { Id = 6, CategoryId = 3, Initial = "Cake", Name = "Cake", Description = "High quality cake", Active = true, Created = DateTime.UtcNow }
                );

            modelBuilder.Entity<Variant>()
                .HasData(
                    new Variant() { Id = 1, ProductId = 1, Initial = "Coco", Name = "Coconat", Description = "Coconat rice", Price = 25000, Stock = 10, Active = true, Created = DateTime.UtcNow },
                    new Variant() { Id = 2, ProductId = 1, Initial = "Chicken", Name = "Chicken", Description = "Chicken rice", Price = 27000, Stock = 8, Active = true, Created = DateTime.UtcNow },

                    new Variant() { Id = 3, ProductId = 2, Initial = "MdChicken", Name = "Medium Chicken", Description = "Medium chicken pizza", Price = 47500, Stock = 8, Active = true, Created = DateTime.UtcNow },
                    new Variant() { Id = 4, ProductId = 2, Initial = "LgChicken", Name = "Large Chicken", Description = "Large chicken pizza", Price = 65000, Stock = 6, Active = true, Created = DateTime.UtcNow },
                    
                    new Variant() { Id = 5, ProductId = 3, Initial = "Expresso", Name = "Expresso", Description = "Expresso coffee", Price = 18000, Stock = 19, Active = true, Created = DateTime.UtcNow },
                    new Variant() { Id = 6, ProductId = 3, Initial = "Cappucino", Name = "Cappucino", Description = "Cappucino coffee", Price = 22000, Stock = 12, Active = true, Created = DateTime.UtcNow },

                    new Variant() { Id = 7, ProductId = 4, Initial = "Mango", Name = "Mango", Description = "Fresh mango juice", Price = 19000, Stock = 11, Active = true, Created = DateTime.UtcNow },
                    new Variant() { Id = 8, ProductId = 4, Initial = "Orange", Name = "Pizza", Description = "Fresh orange juice", Price = 19000, Stock = 13, Active = true, Created = DateTime.UtcNow },
                    
                    new Variant() { Id = 9, ProductId = 5, Initial = "Chocolate", Name = "Chocolate", Description = "Healt chocolate pudding", Price = 9000, Stock = 7, Active = true, Created = DateTime.UtcNow },
                    new Variant() { Id = 10, ProductId = 5, Initial = "Vanilla", Name = "Vanilla", Description = "Healt vanilla pudding", Price = 9000, Stock = 8, Active = true, Created = DateTime.UtcNow },
                    
                    new Variant() { Id = 11, ProductId = 6, Initial = "Cup", Name = "Cup", Description = "Delicious cup cake", Price = 12000, Stock = 15, Active = true, Created = DateTime.UtcNow },
                    new Variant() { Id = 12, ProductId = 6, Initial = "Beef", Name = "Beef", Description = "Fresh beef cake from the open", Price = 17500, Stock = 11, Active = true, Created = DateTime.UtcNow }
                );
        }
    }
}
