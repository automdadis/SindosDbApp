using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SindosDbAppweb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAbroad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apofash",
                table: "ABROADS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Apofash",
                table: "ABROADS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
