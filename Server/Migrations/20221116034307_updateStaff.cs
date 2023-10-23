using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDCARDS.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_staff",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "staff",
                newName: "Staff");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "staff");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_staff",
                table: "staff",
                column: "Id");
        }
    }
}
