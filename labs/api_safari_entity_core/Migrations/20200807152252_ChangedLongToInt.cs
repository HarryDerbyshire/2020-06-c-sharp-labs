using Microsoft.EntityFrameworkCore.Migrations;

namespace api_safari_entity_core.Migrations
{
    public partial class ChangedLongToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "animal_types",
                columns: table => new
                {
                    typeId = table.Column<int>(nullable: false),
                    typeName = table.Column<string>(type: "varchar(40)", nullable: true),
                    numberOfLegs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animal_types", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    animalId = table.Column<int>(nullable: false),
                    animalName = table.Column<string>(type: "varchar(50)", nullable: true),
                    typeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.animalId);
                    table.ForeignKey(
                        name: "FK_animals_animal_types_typeId",
                        column: x => x.typeId,
                        principalTable: "animal_types",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animals_typeId",
                table: "animals",
                column: "typeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "animal_types");
        }
    }
}
