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

    public virtual DbSet<City> Cities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WS-01\\SQLEXPRESS;Initial Catalog=202230548MVCProject;Persist Security Info=True;User ID=sa;Password=admin123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.CityId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("cityId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("province");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
