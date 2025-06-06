using System;
using System.Collections.Generic;
using FanClubAPI.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace FanClubAPI.Models.Contexts;

public partial class FanclubContext : DbContext
{
    public FanclubContext()
    {
    }

    public FanclubContext(DbContextOptions<FanclubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Albums> Albums { get; set; }

    public virtual DbSet<Concerts> Concerts { get; set; }

    public virtual DbSet<Members> Members { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Photos> Photos { get; set; }

    public virtual DbSet<Setlists> Setlists { get; set; }

    public virtual DbSet<Songs> Songs { get; set; }

    public virtual DbSet<Videos> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=fanclubdb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.18-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Albums>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Concerts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Members>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.PublishDate).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<Photos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.UploadedAt).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<Setlists>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Concert).WithMany(p => p.Setlists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("setlists_ibfk_1");

            entity.HasOne(d => d.Song).WithMany(p => p.Setlists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("setlists_ibfk_2");
        });

        modelBuilder.Entity<Songs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("songs_ibfk_1");
        });

        modelBuilder.Entity<Videos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.UploadedAt).HasDefaultValueSql("current_timestamp()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
