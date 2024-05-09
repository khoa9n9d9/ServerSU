using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SUServer.Models;

public partial class ShopSuContext : DbContext
{
    public ShopSuContext()
    {
    }

    public ShopSuContext(DbContextOptions<ShopSuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ShopSU ;User ID=sa;Password = 123456;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Colors)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("colors");
            entity.Property(e => e.Content)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.Image1)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image1");
            entity.Property(e => e.Image2)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image2");
            entity.Property(e => e.Image3)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image3");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Sizes)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("sizes");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Url)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
