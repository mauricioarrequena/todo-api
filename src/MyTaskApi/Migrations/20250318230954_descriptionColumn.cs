using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTaskApi.Migrations
{
    /// <inheritdoc />
    public partial class descriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptoin",
                table: "Tasks",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "Descriptoin");
        }
    }
}
