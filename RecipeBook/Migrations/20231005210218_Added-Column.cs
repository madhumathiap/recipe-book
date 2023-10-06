using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeSteps",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "RecipeIngredients",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeSteps",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RecipeIngredients",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
