using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _202230548_CoffeeShop.ModelsDb;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WS-01\\SQLEXPRESS;Database=202230548MVCProject;User Id=sa;Password=admin123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            entity.HasIndex(e => e.CustomerId, "IX_customer").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("customerId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cityId");
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("creditCardNumber");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
