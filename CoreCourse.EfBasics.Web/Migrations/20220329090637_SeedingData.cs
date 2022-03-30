using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCourse.EfBasics.Web.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GradProg" },
                    { 2, "GradNtw" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Jimi", "Hendrix" },
                    { 2, "Bob", "Marley" },
                    { 3, "Chris", "Rock" },
                    { 4, "Will", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "DepartmentId", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, 1, "Bart", "Soete" },
                    { 2, 1, "William", "Schokkelé" },
                    { 3, 1, "Joachim", "François" },
                    { 4, 1, "Siegfried", "Derdeyn" }
                });

            migrationBuilder.InsertData(
                table: "ContactInfo",
                columns: new[] { "Id", "Email", "Phone", "TeacherId" },
                values: new object[,]
                {
                    { 1, "bart.soete@mail.com", null, 1 },
                    { 2, "william.schok@mail.com", null, 2 },
                    { 3, "joachim.franc@mail.com", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "DBS", 1 },
                    { 5, "CIA", 1 },
                    { 2, "WFA", 2 },
                    { 6, "CIB", 2 },
                    { 3, "WBA", 3 },
                    { 7, "MDE", 3 },
                    { 4, "GAM", 4 },
                    { 8, "PRI", 4 },
                    { 9, "PRE", 4 }
                });

            migrationBuilder.InsertData(
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 4 },
                    { 4, 1 },
                    { 8, 3 },
                    { 9, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactInfo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactInfo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "CoursesId", "StudentsId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
