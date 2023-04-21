using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLinkServices.Web.Migrations
{
    public partial class AddAccountHandling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Appointments",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GuestId",
                table: "Appointments",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Guests_GuestId",
                table: "Appointments",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Guests_GuestId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GuestId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Appointments",
                newName: "Duration");
        }
    }
}
