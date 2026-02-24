using Microsoft.EntityFrameworkCore;
using PizzaX.Domain.Entities;
using PizzaX.Domain.Enums.Product;
using PizzaX.Domain.Enums.User;

namespace PizzaX.Infrastructure.Data
{
    public sealed class PizzaXDbContext : DbContext
    {
        /*// <----- DbSets -----> //*/
        public DbSet<User> Users => Set<User>();
        //public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<PizzaVariety> PizzaVarieties => Set<PizzaVariety>();
        //public DbSet<DealItem> DealItems => Set<DealItem>();
        //public DbSet<Deal> Deals => Set<Deal>();

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

                // Role is required
                builder.Property(u => u.UserRole)
                       .HasColumnName("Role")
                       .HasDefaultValue(UserRole.Customer)
                       .IsRequired();

                //// One-to-One relation with the Employee
                //builder.HasOne(u => u.Employee)
                //       .WithOne(e => e.User)
                //       .OnDelete(DeleteBehavior.Cascade);
            });

            ///*/ <----- Employee - Configuration -----> /*/
            //modelBuilder.Entity<Employee>(builder =>
            //{
            //    // One-to-One relation with the User
            //    builder.HasOne(e => e.User)
            //           .WithOne(u => u.Employee)
            //           .HasForeignKey<Employee>(e => e.UserId)
            //           .OnDelete(DeleteBehavior.Restrict);

            //    // Normal Properties - Configuration
            //    builder.Property(e => e.JobRole)
            //           .HasColumnName("JobRole")
            //           .IsRequired();

            //    builder.Property(e => e.Shift)
            //           .HasColumnName("Shift")
            //           .IsRequired();

            //    builder.Property(e => e.JoiningDate)
            //           .HasColumnName("JoiningDate")
            //           .IsRequired();

            //    builder.Property(e => e.LeftDate)
            //           .HasColumnName("LeftDate");

            //    // Ones some value-objects //

            //    // Name - Configuration
            //    builder.OwnsOne(e => e.Name, name =>
            //    {
            //        name.Property(n => n.FirstName)
            //            .HasColumnName("FirstName")
            //            .IsRequired();

            //        name.Property(n => n.MidName)
            //            .HasColumnName("MiddleName");

            //        name.Property(n => n.LastName)
            //            .HasColumnName("LastName")
            //            .IsRequired();

            //        name.Property(n => n.FatherName)
            //            .HasColumnName("FatherName")
            //            .IsRequired();
            //    });

            //    // CNIC - Configuration
            //    builder.OwnsOne(e => e.CNIC, cnic =>
            //    {
            //        cnic.Property(c => c.Value)
            //            .HasColumnName("CNIC")
            //            .IsRequired();

            //        cnic.HasIndex(c => c.Value)
            //            .IsUnique();
            //    });

            //    // Address - Configuration
            //    builder.OwnsOne(e => e.Address, address =>
            //    {
            //        address.Property(a => a.House)
            //               .HasColumnName("AddressHouse")
            //               .IsRequired();

            //        address.HasIndex(a => a.House)
            //               .IsUnique();

            //        address.Property(a => a.Area)
            //               .HasColumnName("AddressArea")
            //               .IsRequired();

            //        address.Property(a => a.Street)
            //               .HasColumnName("AddressStreet");

            //        address.Property(a => a.City)
            //               .HasColumnName("AddressCity")
            //               .IsRequired();

            //        address.Property(a => a.Province)
            //               .HasColumnName("AddressProvince");

            //        address.Property(a => a.Country)
            //               .HasColumnName("AddressCountry");
            //    });

            //    // Contact - Configuration
            //    builder.OwnsOne(e => e.Contact, contact =>
            //    {
            //        contact.Property(c => c.Value)
            //               .HasColumnName("Contact");

            //        contact.HasIndex(c => c.Value)
            //               .IsUnique();
            //    });

            //    // Salary - Configuration
            //    builder.OwnsOne(e => e.Salary, salary =>
            //    {
            //        salary.Property(s => s.Value)
            //              .HasColumnName("Salary")
            //              .IsRequired();
            //    });
            //});

            /*/ <----- Product - Configuration -----> /*/
            modelBuilder.Entity<Product>(builder =>
            {
                // Price
                builder.OwnsOne(p => p.Price, price =>
                {
                    price.Property(p => p.UnitPrice)
                         .HasColumnName("Price")
                         .IsRequired();
                });

                // Stock Status
                builder.Property(p => p.StockStatus)
                       .HasColumnName("StockStatus")
                       .HasDefaultValue(StockStatus.InStock)
                       .IsRequired();

                // Product Type
                builder.Property(p => p.ProductType)
                       .HasColumnName("ProductType")
                       .IsRequired();

                // Product to Pizza - Relation
                builder.HasOne(p => p.Pizza)
                       .WithOne(p => p.Product)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            /*/ <----- Pizza - Configuration -----> /*/
            modelBuilder.Entity<Pizza>(builder =>
            {
                // Pizza to Product - Relation
                builder.HasOne(p => p.Product)
                       .WithOne(p => p.Pizza)
                       .HasForeignKey<Pizza>(p => p.ProductId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Pizza to Variety - Relation
                builder.HasOne(p => p.Variety)
                       .WithMany(v => v.Pizzas)
                       .HasForeignKey(p => p.VarietyId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Pizza - Size
                builder.Property(p => p.Size)
                       .HasColumnName("Size")
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
                       .HasColumnName("Name")
                       .HasMaxLength(50)
                       .IsRequired();

                builder.HasIndex(v => v.Name)
                       .IsUnique();
            });

            ///*/ <----- Deal Item - Configuration -----> /*/
            //modelBuilder.Entity<DealItem>(builder =>
            //{
            //    // Product Relation
            //    builder.HasOne(i => i.Product)
            //           .WithMany()
            //           .HasForeignKey(i => i.ProductId)
            //           .OnDelete(DeleteBehavior.Restrict);

            //    // Deal Relation
            //    builder.HasOne(i => i.Deal)
            //           .WithMany(d => d.DealItems)
            //           .HasForeignKey(i => i.DealId)
            //           .OnDelete(DeleteBehavior.Cascade);

            //    // Quantity
            //    builder.OwnsOne(i => i.Quantity, quantity =>
            //    {
            //        quantity.Property(q => q.Value)
            //                .HasColumnName("Quantity")
            //                .IsRequired();
            //    });
            //});

            ///*/ <----- Deal - Configuration -----> /*/
            //modelBuilder.Entity<Deal>(builder =>
            //{
            //    // Name Property
            //    builder.Property(d => d.Name)
            //           .HasColumnName("DealName")
            //           .HasMaxLength(10)
            //           .IsRequired();

            //    builder.HasIndex(d => d.Name)
            //           .IsUnique();

            //    // Description property
            //    builder.Property(d => d.Description)
            //           .HasMaxLength(75);

            //    // Price property
            //    builder.OwnsOne(d => d.Price, price =>
            //    {
            //        price.Property(p => p.UnitPrice)
            //             .HasColumnName("Price")
            //             .IsRequired();
            //    });

            //    // Deal Items property
            //    builder.HasMany(d => d.DealItems)
            //           .WithOne(i => i.Deal)
            //           .HasForeignKey(i => i.DealId)
            //           .OnDelete(DeleteBehavior.Cascade);
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
