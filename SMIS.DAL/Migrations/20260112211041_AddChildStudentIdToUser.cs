using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMIS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddChildStudentIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildStudentId",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildStudentId",
                table: "Users");
        }
    }
}
