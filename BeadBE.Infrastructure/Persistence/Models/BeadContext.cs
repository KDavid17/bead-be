using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeadBE.Infrastructure.Persistence.Models
{
    public partial class BeadContext : DbContext
    {
        public BeadContext()
        {
        }

        public BeadContext(DbContextOptions<BeadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingOrder> BookingOrders { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DAVID-LAPTOP\\MSSQLSERVER01;Database=Bead;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Users");
            });

            modelBuilder.Entity<BookingOrder>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingOrders)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingOrders_Bookings");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.BookingOrders)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingOrders_Foods");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipes_Foods");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipes_Ingredients");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Tables_Bookings");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
