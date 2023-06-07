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
            entity.HasNoKey();

            entity.Property(e => e.Challanger).HasColumnName("challanger");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Opponent).HasColumnName("opponent");
            entity.Property(e => e.Winner).HasColumnName("winner");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.PlayerId).HasColumnName("playerId");
            entity.Property(e => e.Score).HasColumnName("score");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
