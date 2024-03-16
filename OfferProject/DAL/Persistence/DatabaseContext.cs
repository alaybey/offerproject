using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Common;

namespace DAL.Persistence;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Offer> Offers { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Mode> Modes { get; set; }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<PackageType> PackageTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity
            .HasOne(e => e.PackageType)
            .WithMany()
            .HasForeignKey(e => e.PackageTypeId);
        });
        modelBuilder.Entity<Offer>(entity =>
        {
            entity
            .HasOne(e => e.Mode)
            .WithMany()
            .HasForeignKey(e => e.ModeId);
        });
        modelBuilder.Entity<Offer>(entity =>
        {
            entity
            .HasOne(e => e.Country)
            .WithMany()
            .HasForeignKey(e => e.CountryId);
        });
        modelBuilder.Entity<Offer>(entity =>
        {
            entity
            .HasOne(e => e.City)
            .WithMany()
            .HasForeignKey(e => e.CityId);
        });
        modelBuilder.Entity<Offer>(entity =>
        {
            entity
            .HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyId);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity
            .HasMany(e => e.Cities)
            .WithOne(e => e.Country)
            .HasForeignKey(e => e.CountryId)
            .IsRequired();
        });

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "USA" },
            new Country { Id = 2, Name = "China" },
            new Country { Id = 3, Name = "Turkey" }
        );

        modelBuilder.Entity<City>(entity =>
        {
            entity
            .HasOne(e => e.Country)
            .WithMany(e => e.Cities)
            .HasForeignKey(e => e.CountryId)
            .IsRequired();
        });

        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "New York" , CountryId = 1},
            new City { Id = 2, Name = "Los Angeles" , CountryId = 1},
            new City { Id = 3, Name = "Miami" , CountryId = 1},
            new City { Id = 4, Name = "Minnesota" , CountryId = 1},
            new City { Id = 5, Name = "Beijing" , CountryId = 2},
            new City { Id = 6, Name = "Shanghai" , CountryId = 2},
            new City { Id = 7, Name = "Istanbul" , CountryId = 3},
            new City { Id = 8, Name = "Izmir" , CountryId = 3}
        );

        modelBuilder.Entity<Mode>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Mode>().HasData(
            new Mode { Id = 1, Value = "LCL" },
            new Mode { Id = 2, Value = "FCL" },
            new Mode { Id = 3, Value = "Air" }
        );

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Currency>().HasData(
            new Currency { Id = 1, Code = "USD", Name = "US Dollar" },
            new Currency { Id = 2, Code = "CNY", Name = "Chinese Yuan" },
            new Currency { Id = 3, Code = "TRY", Name = "Turkish Lira" }
        );

        modelBuilder.Entity<PackageType>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<PackageType>().HasData(
            new PackageType { Id = 1, Value = "Pallets" },
            new PackageType { Id = 2, Value = "Boxes" },
            new PackageType { Id = 3, Value = "Cartons" }
        );
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.CreatedBy = "client";
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedOn = DateTime.Now;
                    entry.Entity.UpdatedBy = "client";
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }

}
