using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLinkServices.Web.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarServiceImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarServiceId = table.Column<int>(type: "int", nullable: false),
                    ImageSmall = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageLarge = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServiceImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServiceImages_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_CarServiceImages_CarServiceId",
                table: "CarServiceImages",
                column: "CarServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "CarServiceImages");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
