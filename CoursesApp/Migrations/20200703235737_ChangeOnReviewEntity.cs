using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursesApp.Migrations
{
    public partial class ChangeOnReviewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "id");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Reviews",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Courses_CourseId",
                table: "Reviews",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
