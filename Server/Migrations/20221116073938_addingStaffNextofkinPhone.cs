using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDCARDS.Server.Migrations
{
    /// <inheritdoc />
    public partial class addingStaffNextofkinPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NextOfKinPhone",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextOfKinPhone",
                table: "Staff");
        }
    }
}
