using CoffeeJournal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }


        public virtual DbSet<Brew> Brews { get; set; }

        public virtual DbSet<Coffee> Coffees { get; set; }

        public virtual DbSet<Flavor> Flavors { get; set; }

        public virtual DbSet<FlavorsCoffee> FlavorsCoffees { get; set; }

        public virtual DbSet<Rate> Rates { get; set; }

        public virtual DbSet<Roast> Roasts { get; set; }

        public virtual DbSet<RoastCoffee> RoastCoffees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brew>(entity =>
            {
                entity.HasKey(e => e.BrewId).HasName("brew_pkey");

                entity.ToTable("brew");

                entity.Property(e => e.BrewId).HasColumnName("brew_id");
                entity.Property(e => e.BrewCoffeeWeight).HasColumnName("brew_coffee_weight");
                entity.Property(e => e.BrewGrindSize).HasColumnName("brew_grind_size");
                entity.Property(e => e.BrewRatio)
                    .HasMaxLength(50)
                    .HasColumnName("brew_ratio");
                entity.Property(e => e.BrewTime).HasColumnName("brew_time");
                entity.Property(e => e.BrewWaterVolume).HasColumnName("brew_water_volume");
                entity.Property(e => e.CoffeeId).HasColumnName("coffee_id");

                entity.HasOne(d => d.Coffee).WithMany(p => p.Brews)
                    .HasForeignKey(d => d.CoffeeId)
                    .HasConstraintName("brew_coffee_id_fkey");
            });

            modelBuilder.Entity<Coffee>(entity =>
            {
                entity.HasKey(e => e.CoffeeId).HasName("coffee_pkey");

                entity.ToTable("coffee");

                entity.Property(e => e.CoffeeId).HasColumnName("coffee_id");
                entity.Property(e => e.CoffeBrand)
                    .HasMaxLength(50)
                    .HasColumnName("coffe_brand");
                entity.Property(e => e.CoffeRegion)
                    .HasMaxLength(60)
                    .HasColumnName("coffe_region");
                entity.Property(e => e.CoffeeName)
                    .HasMaxLength(50)
                    .HasColumnName("coffee_name");
            });

            modelBuilder.Entity<Flavor>(entity =>
            {
                entity.HasKey(e => e.FlavorId).HasName("flavors_pkey");

                entity.ToTable("flavors");

                entity.Property(e => e.FlavorId).HasColumnName("flavor_id");
                entity.Property(e => e.FlavorDescription)
                    .HasMaxLength(50)
                    .HasColumnName("flavor_description");
            });

            modelBuilder.Entity<FlavorsCoffee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("flavors_coffee_pkey");

                entity.ToTable("flavors_coffee");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CoffeeId).HasColumnName("coffee_id");
                entity.Property(e => e.FlavorId).HasColumnName("flavor_id");

                entity.HasOne(d => d.Coffee).WithMany(p => p.FlavorsCoffees)
                    .HasForeignKey(d => d.CoffeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coffee_id");

                entity.HasOne(d => d.Flavor).WithMany(p => p.FlavorsCoffees)
                    .HasForeignKey(d => d.FlavorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flavor_id");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(e => e.RateId).HasName("rate_pkey");

                entity.ToTable("rate");

                entity.Property(e => e.RateId).HasColumnName("rate_id");
                entity.Property(e => e.CoffeeId).HasColumnName("coffee_id");
                entity.Property(e => e.RateAppearance).HasColumnName("rate_appearance");
                entity.Property(e => e.RateAroma).HasColumnName("rate_aroma");
                entity.Property(e => e.RateFlavor).HasColumnName("rate_flavor");
                entity.Property(e => e.RateValue).HasColumnName("rate_value");

                entity.HasOne(d => d.Coffee).WithMany(p => p.Rates)
                    .HasForeignKey(d => d.CoffeeId)
                    .HasConstraintName("rate_coffee_id_fkey");
            });

            modelBuilder.Entity<Roast>(entity =>
            {
                entity.HasKey(e => e.RoastId).HasName("roast_pkey");

                entity.ToTable("roast");

                entity.Property(e => e.RoastId).HasColumnName("roast_id");
                entity.Property(e => e.RoastDescription)
                    .HasMaxLength(50)
                    .HasColumnName("roast_description");
                entity.Property(e => e.RoastRate).HasColumnName("roast_rate");
            });

            modelBuilder.Entity<RoastCoffee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("roast_coffee_pkey");

                entity.ToTable("roast_coffee");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CoffeeId).HasColumnName("coffee_id");
                entity.Property(e => e.RoastId).HasColumnName("roast_id");

                entity.HasOne(d => d.Coffee).WithMany(p => p.RoastCoffees)
                    .HasForeignKey(d => d.CoffeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coffee_id");

                entity.HasOne(d => d.Roast).WithMany(p => p.RoastCoffees)
                    .HasForeignKey(d => d.RoastId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roast_id");
            });

        }

    }
}