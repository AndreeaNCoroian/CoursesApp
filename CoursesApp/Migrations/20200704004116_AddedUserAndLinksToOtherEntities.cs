using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursesApp.Migrations
{
    public partial class AddedUserAndLinksToOtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddedById",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AddedById",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AddedById",
                table: "Reviews",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AddedById",
                table: "Courses",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_AddedById",
                table: "Courses",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_AddedById",
                table: "Reviews",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_AddedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_AddedById",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AddedById",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AddedById",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Courses");
        }
    }
}
