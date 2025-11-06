using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Erstes.Repositories;

public partial class TicketsystemContext : DbContext
{
    public TicketsystemContext()
    {
    }

    public TicketsystemContext(DbContextOptions<TicketsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ersteller> Ersteller { get; set; }

    public virtual DbSet<Ticket> Ticket { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Ticketsystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ersteller>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__Erstelle__C1971B53093E9344");

            entity.Property(e => e.Aktiv).HasDefaultValue(true);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Nachname).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(20);
            entity.Property(e => e.Vorname).HasMaxLength(100);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__Ticket__C451DB31E4D45122");

            entity.Property(e => e.Erstelldatum).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LetzteAenderung).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Titel).HasMaxLength(200);

            entity.HasOne(d => d.Ersteller).WithMany(p => p.Ticket)
                .HasForeignKey(d => d.ErstellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Ersteller");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
