// <auto-generated />
using System;
using CoreCourse.EfBasics.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreCourse.EfBasics.Web.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20220329090637_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique()
                        .HasFilter("[TeacherId] IS NOT NULL");

                    b.ToTable("ContactInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bart.soete@mail.com",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "william.schok@mail.com",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "joachim.franc@mail.com",
                            TeacherId = 3
                        });
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DBS",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "WFA",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "WBA",
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "GAM",
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "CIA",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "CIB",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "MDE",
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "PRI",
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "PRE",
                            TeacherId = 4
                        });
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "GradProg"
                        },
                        new
                        {
                            Id = 2,
                            Name = "GradNtw"
                        });
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Firstname = "Jimi",
                            Lastname = "Hendrix"
                        },
                        new
                        {
                            Id = 2,
                            Firstname = "Bob",
                            Lastname = "Marley"
                        },
                        new
                        {
                            Id = 3,
                            Firstname = "Chris",
                            Lastname = "Rock"
                        },
                        new
                        {
                            Id = 4,
                            Firstname = "Will",
                            Lastname = "Smith"
                        });
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Firstname = "Bart",
                            Lastname = "Soete"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            Firstname = "William",
                            Lastname = "Schokkelé"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 1,
                            Firstname = "Joachim",
                            Lastname = "François"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 1,
                            Firstname = "Siegfried",
                            Lastname = "Derdeyn"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");

                    b.HasData(
                        new
                        {
                            CoursesId = 1,
                            StudentsId = 1
                        },
                        new
                        {
                            CoursesId = 1,
                            StudentsId = 2
                        },
                        new
                        {
                            CoursesId = 2,
                            StudentsId = 1
                        },
                        new
                        {
                            CoursesId = 3,
                            StudentsId = 4
                        },
                        new
                        {
                            CoursesId = 4,
                            StudentsId = 1
                        },
                        new
                        {
                            CoursesId = 9,
                            StudentsId = 4
                        },
                        new
                        {
                            CoursesId = 8,
                            StudentsId = 3
                        });
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.ContactInfo", b =>
                {
                    b.HasOne("CoreCourse.EfBasics.Core.Entities.Teacher", "Teacher")
                        .WithOne("ContactInfo")
                        .HasForeignKey("CoreCourse.EfBasics.Core.Entities.ContactInfo", "TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Course", b =>
                {
                    b.HasOne("CoreCourse.EfBasics.Core.Entities.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Teacher", b =>
                {
                    b.HasOne("CoreCourse.EfBasics.Core.Entities.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("CoreCourse.EfBasics.Core.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreCourse.EfBasics.Core.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Department", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("CoreCourse.EfBasics.Core.Entities.Teacher", b =>
                {
                    b.Navigation("ContactInfo");

                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
