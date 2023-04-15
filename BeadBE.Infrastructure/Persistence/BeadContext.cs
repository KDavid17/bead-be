using System;
using System.Collections.Generic;
using BeadBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence;

public partial class BeadContext : DbContext
{
    public BeadContext()
    {
    }

    public BeadContext(DbContextOptions<BeadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingCell> BookingCells { get; set; }

    public virtual DbSet<BookingFood> BookingFoods { get; set; }

    public virtual DbSet<Cell> Cells { get; set; }

    public virtual DbSet<Eatery> Eateries { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodIngredient> FoodIngredients { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DAVID-LAPTOP\\MSSQLSERVER01;Database=Bead;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Eatery).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EateryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Eateries");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Users");
        });

        modelBuilder.Entity<BookingCell>(entity =>
        {
            entity.HasOne(d => d.Booking).WithMany(p => p.BookingCells)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingCells_Bookings");

            entity.HasOne(d => d.Cell).WithMany(p => p.BookingCells)
                .HasForeignKey(d => d.CellId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingCells_Cells");
        });

        modelBuilder.Entity<BookingFood>(entity =>
        {
            entity.HasOne(d => d.Booking).WithMany(p => p.BookingFoods)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingFoods_Bookings");

            entity.HasOne(d => d.Food).WithMany(p => p.BookingFoods)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingFoods_Foods");
        });

        modelBuilder.Entity<Cell>(entity =>
        {
            entity.HasOne(d => d.Eatery).WithMany(p => p.Cells)
                .HasForeignKey(d => d.EateryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cells_Eateries");

            entity.HasOne(d => d.Table).WithMany(p => p.Cells)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK_Cells_Tables");
        });

        modelBuilder.Entity<Eatery>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Eateries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Eateries_Users");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Eatery).WithMany(p => p.Foods)
                .HasForeignKey(d => d.EateryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Foods_Eateries");
        });

        modelBuilder.Entity<FoodIngredient>(entity =>
        {
            entity.HasOne(d => d.Food).WithMany(p => p.FoodIngredients)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodIngredients_Foods");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.FoodIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FoodIngredients_Ingredients");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(64);
            entity.Property(e => e.Salt).HasMaxLength(128);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
