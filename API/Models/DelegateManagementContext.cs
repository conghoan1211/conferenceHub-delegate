using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class DelegateManagementContext : DbContext
{
    public DelegateManagementContext()
    {
    }

    public DelegateManagementContext(DbContextOptions<DelegateManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<ConferenceDelegate> ConferenceDelegates { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =localhost; database =DelegateManagement;uid=sa;pwd=hoancute;TrustServerCertificate=true;Integrated Security = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conferen__3214EC0713E63A62");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CreateUser).HasMaxLength(36);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeadlineDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasPrecision(0);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.StartTime).HasPrecision(0);
            entity.Property(e => e.Thumbnail).HasMaxLength(255);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasMaxLength(36);

            entity.HasOne(d => d.CreateUserNavigation).WithMany(p => p.Conferences)
                .HasForeignKey(d => d.CreateUser)
                .HasConstraintName("FK__Conferenc__Creat__4222D4EF");

            entity.HasOne(d => d.Location).WithMany(p => p.Conferences)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conferenc__Locat__412EB0B6");
        });

        modelBuilder.Entity<ConferenceDelegate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conferen__3214EC073EF1ECBB");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ConferenceId).HasMaxLength(36);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(36);

            entity.HasOne(d => d.Conference).WithMany(p => p.ConferenceDelegates)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conferenc__Confe__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.ConferenceDelegates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conferenc__UserI__46E78A0C");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Files__3214EC07AC0004DD");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ConferenceId).HasMaxLength(36);
            entity.Property(e => e.FilePath).HasMaxLength(500);
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UploadedBy).HasMaxLength(36);

            entity.HasOne(d => d.Conference).WithMany(p => p.Files)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Files__Conferenc__4E88ABD4");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Files)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Files__UploadedB__4F7CD00D");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07A50660EF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(120);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07D11EA222");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ConferenceId).HasMaxLength(36);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Conference).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Confe__4AB81AF0");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC07C5A2AAD1");

            entity.HasIndex(e => e.Name, "UQ__Position__737584F65DE49799").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C82A477B9");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345A9109AA").IsUnique();

            entity.Property(e => e.UserId).HasMaxLength(36);
            entity.Property(e => e.Avatar).HasMaxLength(500);
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.CreateUser).HasMaxLength(36);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.GoogleId).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
            entity.Property(e => e.UpdateUser).HasMaxLength(36);

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Users__PositionI__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
