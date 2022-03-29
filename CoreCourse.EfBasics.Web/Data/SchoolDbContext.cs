using CoreCourse.EfBasics.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreCourse.EfBasics.Web.Data
{
    public class SchoolDbContext : DbContext
    {
        //register the entity classes
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
