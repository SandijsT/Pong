using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pong.Models;

namespace Pong.Contexts;

public partial class PongContext : DbContext
{
    public PongContext()
    {
    }

    public PongContext(DbContextOptions<PongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Pong;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Games__2AB897FD1E33B600");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.ChallangerNavigation).WithMany(p => p.GameChallangerNavigations)
                .HasForeignKey(d => d.Challanger)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__Challange__300424B4");

            entity.HasOne(d => d.OpponentNavigation).WithMany(p => p.GameOpponentNavigations)
                .HasForeignKey(d => d.Opponent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__Opponent__30F848ED");

            entity.HasOne(d => d.WinnerNavigation).WithMany(p => p.GameWinnerNavigations)
                .HasForeignKey(d => d.Winner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__Winner__31EC6D26");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__4A4E74C85D8B7F96");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
