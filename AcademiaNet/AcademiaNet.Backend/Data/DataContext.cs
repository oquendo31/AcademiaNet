using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace AcademiaNet.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Administrator> Administrators { get; set; }

      
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Institution>().HasIndex(x => x.Name).IsUnique();
        DisableCascadingDelete(modelBuilder);

    }
    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var realtionship in relationships)
        {
            realtionship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}