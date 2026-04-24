using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using News_Management.Application.Interfaces;
using News_Management.Domain.Entities;


namespace News_Management.Infrastructure.Persistence;

public partial class NewsManagementDbContext : DbContext, IApplicationDbContext
{
    public NewsManagementDbContext()
    {
    }

    public NewsManagementDbContext(DbContextOptions<NewsManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuNews> MenuNews { get; set; }

    public virtual DbSet<News> News { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            entity.Property(e => e.Name)
                .HasMaxLength(255);

            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.Images)
                .HasMaxLength(255);

            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(255);

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<MenuNews>(entity =>
        {
            entity.HasKey(e => new { e.MenuId, e.NewsId });

            entity.HasOne(d => d.Menu)
                .WithMany(p => p.MenuNews)
                .HasForeignKey(d => d.MenuId);

            entity.HasOne(d => d.News)
                .WithMany(p => p.MenuNews)
                .HasForeignKey(d => d.NewsId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}