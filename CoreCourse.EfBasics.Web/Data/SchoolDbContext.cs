using CoreCourse.EfBasics.Core.Entities;
using CoreCourse.EfBasics.Web.Data.Seeding;
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
        public DbSet<ContactInfo> ContactInfos { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //teacher configuration
            modelBuilder.Entity<Teacher>()
                .Property(t => t.Firstname).IsRequired();
            modelBuilder.Entity<Teacher>()
                .Property(t => t.Lastname).IsRequired();
            //students
            modelBuilder.Entity<Student>()
                .Property(s => s.Firstname)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Student>()
             .Property(s => s.Lastname)
             .IsRequired()
             .HasMaxLength(50);
            //courses
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(120);
            //seed the data
            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
