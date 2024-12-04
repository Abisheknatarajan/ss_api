using System;
using System.Collections.Generic;
using DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Context;

public partial class ApiDbContext : DbContext  // Marking as partial class
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Warning regarding connection string here
        optionsBuilder.UseSqlServer("Server=DESKTOP-5R7V2DJ\\SQLEXPRESS;Database=SystemStatus;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACA57B3914");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);  // Calls partial method
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);  // Partial method definition
}

