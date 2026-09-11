using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=OnlineCourseDb;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}