using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace FanClubAPI.Models;

public partial class FanClubContext : DbContext
{
    public FanClubContext()
    {
    }

    public FanClubContext(DbContextOptions<FanClubContext> options)
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
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=FanClubDB;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.18-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Albums>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("albums");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CoverUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Concerts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("concerts");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.TicketUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Venue).HasMaxLength(100);
        });

        modelBuilder.Entity<Members>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("members");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhotoUrl).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("news");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.PublishDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Photos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photos");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Url).HasMaxLength(255);
        });

        modelBuilder.Entity<Setlists>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("setlists");

            entity.HasIndex(e => e.ConcertId, "IX_Setlists_ConcertId");

            entity.HasIndex(e => e.SongId, "IX_Setlists_SongId");

            entity.HasIndex(e => new { e.ConcertId, e.SongOrder }, "UQ_Concert_SongOrder").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ConcertId).HasColumnType("int(11)");
            entity.Property(e => e.SongId).HasColumnType("int(11)");
            entity.Property(e => e.SongOrder).HasColumnType("int(11)");

            entity.HasOne(d => d.Concert).WithMany(p => p.Setlists)
                .HasForeignKey(d => d.ConcertId)
                .HasConstraintName("FK_Setlists_Concert");

            entity.HasOne(d => d.Song).WithMany(p => p.Setlists)
                .HasForeignKey(d => d.SongId)
                .HasConstraintName("FK_Setlists_Song");
        });

        modelBuilder.Entity<Songs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("songs");

            entity.HasIndex(e => e.AlbumId, "IX_Songs_AlbumId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AlbumId).HasColumnType("int(11)");
            entity.Property(e => e.Duration).HasMaxLength(10);
            entity.Property(e => e.Lyrics).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.TrackNumber).HasColumnType("int(11)");

            entity.HasOne(d => d.Album).WithMany(p => p.Songs)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_Songs_Album");
        });

        modelBuilder.Entity<Videos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("videos");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.YoutubeUrl).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
