using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedMistakesSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CocnertDate",
                table: "Concerts",
                newName: "ConcertImage");

            migrationBuilder.AddColumn<string>(
                name: "ConcertDate",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcertDate",
                table: "Concerts");

            migrationBuilder.RenameColumn(
                name: "ConcertImage",
                table: "Concerts",
                newName: "CocnertDate");
        }
    }
}
