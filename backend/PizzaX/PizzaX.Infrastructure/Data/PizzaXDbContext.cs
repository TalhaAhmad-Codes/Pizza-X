using Microsoft.EntityFrameworkCore;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.User;

namespace PizzaX.Infrastructure.Data
{
    public sealed class PizzaXDbContext : DbContext
    {
        /*// <----- DbSets -----> //*/
        public DbSet<User> Users => Set<User>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<PizzaVariety> PizzaVarieties => Set<PizzaVariety>();
        public DbSet<Fries> Fries => Set<Fries>();
        public DbSet<Drink> Drinks => Set<Drink>();
        
        // Constructor
        public PizzaXDbContext(DbContextOptions<PizzaXDbContext> options) : base(options) { }

        // Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*/ <----- User - Configuration -----> /*/
            modelBuilder.Entity<User>(builder =>
            {
                // Owns a unique (email) value object
                builder.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Value)
                         .HasColumnName("Email")
                         .IsRequired();

                    email.HasIndex(e => e.Value)
                         .IsUnique();
                });

                // Owns (password) value object
                builder.OwnsOne(u => u.Password, password =>
                {
                    password.Property(p => p.Hash)
                        .HasColumnName("Password")
                        .IsRequired();
                });

                // Username is required and must be unique
                builder.Property(u => u.Username)
                       .IsRequired();

                builder.HasIndex(u => u.Username)
                       .IsUnique();

                // Role is required
                builder.Property(u => u.UserRole)
                       .HasColumnName("Role")
                       .HasDefaultValue(UserRole.Customer)
                       .IsRequired();
            });

            /*/ <----- Pizza - Configuration -----> /*/
            modelBuilder.Entity<Pizza>(builder =>
            {
                // One-to-Many relation with the variety of pizza
                builder.HasOne(p => p.Variety)
                       .WithMany(v => v.Pizzas)
                       .HasForeignKey(p => p.VarietyId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Size config
                builder.Property(p => p.Size)
                       .HasColumnName("Size")
                       .IsRequired();

                // Product configs
                builder.OwnsOne(p => p.Price, price =>
                {
                    price.Property(r => r.UnitPrice)
                         .HasColumnName("Price")
                         .IsRequired();
                });

                builder.OwnsOne(p => p.Quantity, quantity =>
                {
                    quantity.Property(q => q.Value)
                            .HasColumnName("Quantity")
                            .IsRequired();
                });

                builder.Property(p => p.StockStatus)
                       .HasColumnName("StockStatus")
                       .IsRequired();
            });

            /*/ <----- Pizza Vareity - Configuration -----> /*/
            modelBuilder.Entity<PizzaVariety>(builder =>
            {
                // Many-to-One relation with pizzas
                builder.HasMany(v => v.Pizzas)
                       .WithOne(p => p.Variety)
                       .OnDelete(DeleteBehavior.Cascade);

                // Name property
                builder.Property(v => v.Name)
                       .IsRequired();
                
                builder.HasIndex(v => v.Name)
                       .IsUnique();
            });

            /*/ <----- Fries - Configuration -----> /*/
            modelBuilder.Entity<Fries>(builder =>
            {
                // Category property
                builder.Property(f => f.Category)
                       .IsRequired();

                builder.HasIndex(f => f.Category)
                       .IsUnique();

                // Product configs
                builder.OwnsOne(p => p.Price, price =>
                {
                    price.Property(r => r.UnitPrice)
                         .HasColumnName("Price")
                         .IsRequired();
                });

                builder.OwnsOne(p => p.Quantity, quantity =>
                {
                    quantity.Property(q => q.Value)
                            .HasColumnName("Quantity")
                            .IsRequired();
                });

                builder.Property(p => p.StockStatus)
                       .HasColumnName("StockStatus")
                       .IsRequired();
            });

            /*/ <----- Drink - Configurations -----> /*/
            modelBuilder.Entity<Drink>(builder =>
            {
                // Drink type config
                builder.Property(d => d.DrinkType)
                       .HasColumnName("Type")
                       .IsRequired();

                // Drink details config
                builder.OwnsOne(d => d.DrinkDetails, details =>
                {
                    // Company name
                    details.Property(c => c.Company)
                           .HasColumnName("Company")
                           .IsRequired();

                    // Retailer contact number
                    details.OwnsOne(n => n.RetailerContactNumber, number =>
                    {
                        number.Property(c => c.Value)
                              .HasColumnName("Contact");

                        number.HasIndex(c => c.Value)
                              .IsUnique();
                    });
                });

                // Product configs
                builder.OwnsOne(p => p.Price, price =>
                {
                    price.Property(r => r.UnitPrice)
                         .HasColumnName("Price")
                         .IsRequired();
                });

                builder.OwnsOne(p => p.Quantity, quantity =>
                {
                    quantity.Property(q => q.Value)
                            .HasColumnName("Quantity")
                            .IsRequired();
                });

                builder.Property(p => p.StockStatus)
                       .HasColumnName("StockStatus")
                       .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
