using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CyberShoppee.API.Entities
{
    public partial class CyberShoppeeSprint2Context : DbContext
    {
        public CyberShoppeeSprint2Context()
        {
        }

        public CyberShoppeeSprint2Context(DbContextOptions<CyberShoppeeSprint2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MEENU\\SQLExpress;Database=CyberShoppeeSprint2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.CustomerEmail, "UQ__Customer__8A8E974709F397D1")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Address");

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Contact")
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Email");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Password");

                entity.Property(e => e.CustomerRegistationDate)
                    .HasColumnType("date")
                    .HasColumnName("Customer_RegistationDate");

                entity.Property(e => e.CustomerRole)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Role");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Order_Id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Id");

                entity.Property(e => e.ShoppingCartId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ShoppingCart_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__1DB06A4F");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Orders__Recipe_I__1EA48E88");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .HasConstraintName("FK__Orders__Shopping__1CBC4616");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.HasIndex(e => e.RecipeName, "UQ__Recipe__C0FCFE973F1A3D78")
                    .IsUnique();

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Id");

                entity.Property(e => e.RecipeDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Description");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Name");

                entity.Property(e => e.RecipePrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Recipe_Price");

                entity.Property(e => e.RecipeStock)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Stock");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("Shipping");

                entity.Property(e => e.ShippingId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Shipping_Id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Order_Id");

                entity.Property(e => e.ShippingDate)
                    .HasColumnType("date")
                    .HasColumnName("Shipping_Date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Shipping__Custom__22751F6C");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Shipping__Order___2180FB33");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart");

                entity.Property(e => e.ShoppingCartId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ShoppingCart_Id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.RecipeId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ShoppingC__Custo__18EBB532");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__ShoppingC__Recip__19DFD96B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
