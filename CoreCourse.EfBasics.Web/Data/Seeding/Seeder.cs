using CoreCourse.EfBasics.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreCourse.EfBasics.Web.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //departments data
            var departments = new Department[]
            {
                new Department() {Id=1, Name = "GradProg"},
                new Department() {Id=2, Name = "GradNtw"}
            };
            //student
            var students = new Student[]
            {
                new Student() {Id=1,Firstname="Jimi",Lastname="Hendrix"},
                new Student() {Id=2,Firstname="Bob",Lastname="Marley"},
                new Student() {Id=3,Firstname="Chris",Lastname="Rock"},
                new Student() {Id=4,Firstname="Will",Lastname="Smith"}
            };
            //teachers
            var teachers = new Teacher[]
            {
                    new Teacher{Id=1,Firstname="Bart",Lastname="Soete",DepartmentId=1},
                    new Teacher{Id=2,Firstname="William",Lastname="Schokkelé",DepartmentId=1},
                    new Teacher{Id=3,Firstname="Joachim",Lastname="François",DepartmentId=1},
                    new Teacher{Id=4,Firstname="Siegfried",Lastname="Derdeyn",DepartmentId=1}
            };
            //contactinfo
            var contactInfos = new ContactInfo[]
            {
                new ContactInfo() {Id=1,Email="bart.soete@mail.com",TeacherId=1},
                new ContactInfo() {Id=2,Email="william.schok@mail.com",TeacherId=2},
                new ContactInfo() {Id=3,Email="joachim.franc@mail.com",TeacherId=3}
            };
            //course
            var courses = new Course[]
            {
                new Course() {Id=1,Name="DBS",TeacherId=1},
                new Course() {Id=2,Name="WFA",TeacherId=2},
                new Course() {Id=3,Name="WBA",TeacherId=3},
                new Course() {Id=4,Name="GAM",TeacherId=4},
                new Course() {Id=5,Name="CIA",TeacherId=1},
                new Course() {Id=6,Name="CIB",TeacherId=2},
                new Course() {Id=7,Name="MDE",TeacherId=3},
                new Course() {Id=8,Name="PRI",TeacherId=4},
                new Course() {Id=9,Name="PRE",TeacherId=4},
            };
            //courseStudents use anonymous objects
            var courseStudents = new[] {
                new{CoursesId=1,StudentsId=1 },
                new{CoursesId=1,StudentsId=2 },
                new{CoursesId=2,StudentsId=1 },
                new{CoursesId=3,StudentsId=4 },
                new{CoursesId=4,StudentsId=1 },
                new{CoursesId=9,StudentsId=4 },
                new{CoursesId=8,StudentsId=3 },
            };

            //use the hasdata methods per entity
            //sequence is important!
            //departments
            modelBuilder.Entity<Department>()
                .HasData(departments);
            //students
            modelBuilder.Entity<Student>()
                .HasData(students);
            //teachers
            modelBuilder.Entity<Teacher>()
                .HasData(teachers);
            //contactinfo
            modelBuilder.Entity<ContactInfo>()
                .HasData(contactInfos);
            //courses
            modelBuilder.Entity<Course>()
                .HasData(courses);
            //courseStudents => !! anonymous object
            modelBuilder.Entity("CourseStudent")//"CourseStudent"
                .HasData(courseStudents);
        }
    }
}
