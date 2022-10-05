using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LP304_Takt.Migrations
{
    public partial class Initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QueueId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_QueueId",
                table: "Areas",
                column: "QueueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Queue_QueueId",
                table: "Areas",
                column: "QueueId",
                principalTable: "Queue",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Queue_QueueId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_QueueId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "QueueId",
                table: "Areas");
        }
    }
}
