using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Bijuterii.Migrations
{
    public partial class Material : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Bijuterie",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "MaterialID",
                table: "Bijuterie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireMaterial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bijuterie_MaterialID",
                table: "Bijuterie",
                column: "MaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bijuterie_Material_MaterialID",
                table: "Bijuterie",
                column: "MaterialID",
                principalTable: "Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bijuterie_Material_MaterialID",
                table: "Bijuterie");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Bijuterie_MaterialID",
                table: "Bijuterie");

            migrationBuilder.DropColumn(
                name: "MaterialID",
                table: "Bijuterie");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Bijuterie",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
