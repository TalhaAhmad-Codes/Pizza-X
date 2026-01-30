using Microsoft.EntityFrameworkCore;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.User;
using PizzaX.Domain.ValueObjects.Deal;

namespace PizzaX.Infrastructure.Data
{
    public sealed class PizzaXDbContext : DbContext
    {
        /*// <----- DbSets -----> //*/
        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<PizzaVariety> PizzaVarieties => Set<PizzaVariety>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<Deal> Deals => Set<Deal>();
        
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
                       .HasMaxLength(20)
                       .IsRequired();

                builder.HasIndex(u => u.Username)
                       .IsUnique();

                // Role is required
                builder.Property(u => u.UserRole)
                       .HasColumnName("Role")
                       .HasDefaultValue(UserRole.Customer)
                       .IsRequired();

                // One-to-One relation with the Employee
                builder.HasOne(u => u.Employee)
                       .WithOne(e => e.User)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            /*/ <----- Employee - Configuration -----> /*/
            modelBuilder.Entity<Employee>(builder =>
            {
                // One-to-One relation with the User
                builder.HasOne(e => e.User)
                       .WithOne(u => u.Employee)
                       .HasForeignKey<Employee>(e => e.UserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Normal Properties - Configuration
                builder.Property(e => e.JobRole)
                       .HasColumnName("JobRole")
                       .IsRequired();

                builder.Property(e => e.Shift)
                       .HasColumnName("Shift")
                       .IsRequired();

                builder.Property(e => e.JoiningDate)
                       .HasColumnName("JoiningDate")
                       .IsRequired();

                builder.Property(e => e.LeftDate)
                       .HasColumnName("LeftDate");

                // Ones some value-objects //

                // Name - Configuration
                builder.OwnsOne(e => e.Name, name =>
                {
                    name.Property(n => n.FirstName)
                        .HasColumnName("FirstName")
                        .IsRequired();

                    name.Property(n => n.MidName)
                        .HasColumnName("MiddleName");

                    name.Property(n => n.LastName)
                        .HasColumnName("LastName")
                        .IsRequired();

                    name.Property(n => n.FatherName)
                        .HasColumnName("FatherName")
                        .IsRequired();
                });

                // CNIC - Configuration
                builder.OwnsOne(e => e.CNIC, cnic =>
                {
                    cnic.Property(c => c.Value)
                        .HasColumnName("CNIC")
                        .IsRequired();

                    cnic.HasIndex(c => c.Value)
                        .IsUnique();
                });

                // Address - Configuration
                builder.OwnsOne(e => e.Address, address =>
                {
                    address.Property(a => a.House)
                           .HasColumnName("AddressHouse")
                           .IsRequired();

                    address.HasIndex(a => a.House)
                           .IsUnique();

                    address.Property(a => a.Area)
                           .HasColumnName("AddressArea")
                           .IsRequired();

                    address.Property(a => a.Street)
                           .HasColumnName("AddressStreet");

                    address.Property(a => a.City)
                           .HasColumnName("AddressCity")
                           .IsRequired();

                    address.Property(a => a.Province)
                           .HasColumnName("AddressProvince");

                    address.Property(a => a.Country)
                           .HasColumnName("AddressCountry");
                });

                // Contact - Configuration
                builder.OwnsOne(e => e.Contact, contact =>
                {
                    contact.Property(c => c.Value)
                           .HasColumnName("Contact");

                    contact.HasIndex(c => c.Value)
                           .IsUnique();
                });

                // Salary - Configuration
                builder.OwnsOne(e => e.Salary, salary =>
                {
                    salary.Property(s => s.Value)
                          .HasColumnName("Salary")
                          .IsRequired();
                });
            });

            /*/ <----- Pizza - Configuration -----> /*/
            modelBuilder.Entity<Pizza>(builder =>
            {
                // One-to-Many relation with the variety of pizza
                builder.HasOne(p => p.Variety)
                       .WithMany(v => v.Products)
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

                builder.Property(p => p.Description)
                       .HasColumnName("Description")
                       .HasMaxLength(100);

                builder.Property(p => p.StockStatus)
                       .HasColumnName("StockStatus")
                       .IsRequired();
            });

            /*/ <----- Pizza Vareity - Configuration -----> /*/
            modelBuilder.Entity<PizzaVariety>(builder =>
            {
                // Many-to-One relation with pizzas
                builder.HasMany(v => v.Products)
                       .WithOne(p => p.Variety)
                       .OnDelete(DeleteBehavior.Cascade);

                // Name property
                builder.Property(v => v.Value)
                       .HasColumnName("Name")
                       .HasMaxLength(50)
                       .IsRequired();
                
                builder.HasIndex(v => v.Value)
                       .IsUnique();
            });

            /*/ <----- Product - Configuration -----> /*/
            modelBuilder.Entity<Product>(builder =>
            {
                // One-to-Many relation with the category of "Product Category"
                builder.HasOne(p => p.Category)
                       .WithMany(c => c.Products)
                       .HasForeignKey(p => p.CategoryId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Name config
                builder.Property(p => p.Name)
                       .HasColumnName("Name")
                       .HasMaxLength(50)
                       .IsRequired();

                builder.HasIndex(p => p.Name)
                       .IsUnique();

                // Product configs
                builder.OwnsOne(p => p.Price, price =>
                {
                    price.Property(r => r.UnitPrice)
                         .HasColumnName("Price")
                         .IsRequired();
                });

                builder.Property(p => p.Description)
                       .HasColumnName("Description")
                       .HasMaxLength(100);

                builder.Property(p => p.StockStatus)
                       .HasColumnName("StockStatus")
                       .IsRequired();
            });

            /*/ <----- Product Category - Configuration -----> /*/
            modelBuilder.Entity<ProductCategory>(builder =>
            {
                // Many-to-One relation with products
                builder.HasMany(v => v.Products)
                       .WithOne(p => p.Category)
                       .OnDelete(DeleteBehavior.Cascade);

                // Name property
                builder.Property(v => v.Value)
                       .HasColumnName("Name")
                       .HasMaxLength(50)
                       .IsRequired();

                builder.HasIndex(v => v.Value)
                       .IsUnique();
            });

            /*/ <----- Deal - Configuration -----> /*/
            modelBuilder.Entity<Deal>(builder =>
            {
                // Name Property
                builder.Property(d => d.Name)
                       .HasColumnName("DealName")
                       .HasMaxLength(10)
                       .IsRequired();

                builder.HasIndex(d => d.Name)
                       .IsUnique();

                // Description property
                builder.Property(d => d.Description)
                       .HasMaxLength(75);

                // Price property
                builder.OwnsOne(d => d.Price, price =>
                {
                    price.Property(p => p.UnitPrice)
                         .HasColumnName("Price")
                         .IsRequired();
                });

                // Deal Items property
                builder.OwnsMany(d => d.Items, items =>
                {
                    // Name property
                    items.Property(i => i.Name)
                         .HasColumnName("ItemName")
                         .HasMaxLength(20)
                         .IsRequired();

                    // Quantity property
                    items.Property(i => i.Quantity)
                         .HasColumnName("ItemQuantity")
                         .IsRequired();

                    // Product Id property
                    items.Property(i => i.ProductId)
                         .HasColumnName("ItemProductId")
                         .IsRequired();

                    items.HasIndex(i => i.ProductId)
                         .IsUnique();

                    // One-to-One relations with product
                    items.HasOne(i => i.Product)
                         .WithOne(p => p.DealItem)
                         .OnDelete(DeleteBehavior.Restrict);

                    items.HasOne(i => i.Pizza)
                         .WithOne(p => p.DealItem)
                         .OnDelete(DeleteBehavior.Restrict);

                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
