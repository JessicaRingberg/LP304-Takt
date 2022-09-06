using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LP304_Takt.Migrations
{
    public partial class anotherCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Configs_AreaId",
                table: "Configs");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_AreaId",
                table: "Configs",
                column: "AreaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Configs_AreaId",
                table: "Configs");

            migrationBuilder.CreateIndex(
                name: "IX_Configs_AreaId",
                table: "Configs",
                column: "AreaId");
        }
    }
}
