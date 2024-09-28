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
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AcademicProgram> AcademicPrograms { get; set; }
    public DbSet<EnrollmentPeriod> EnrollmentPeriods { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<PeriodAcademicPrograms> PeriodAcademicPrograms { get; set; }

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