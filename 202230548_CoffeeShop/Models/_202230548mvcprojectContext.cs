using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _202230548_CoffeeShop.Models;

public partial class _202230548mvcprojectContext : DbContext
{
    public _202230548mvcprojectContext()
    {
    }

    public _202230548mvcprojectContext(DbContextOptions<_202230548mvcprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WS-01\\SQLEXPRESS;Initial Catalog=202230548MVCProject;Persist Security Info=True;User ID=sa;Password=admin123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.HasIndex(e => e.CustomerId, "IX_customer").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("creditCardNumber");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("postalCode");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.HasIndex(e => e.ProductId, "IX_product").IsUnique();

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("product_id");
            entity.Property(e => e.AvailableQuantity).HasColumnName("availableQuantity");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(4, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("sale");

            entity.Property(e => e.SaleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("sale_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sale_customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sale_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
