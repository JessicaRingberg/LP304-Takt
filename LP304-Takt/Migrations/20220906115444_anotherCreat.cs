using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LP304_Takt.Migrations
{
    public partial class anotherCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QueueId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Queue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queue", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_QueueId",
                table: "Orders",
                column: "QueueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Queue_QueueId",
                table: "Orders",
                column: "QueueId",
                principalTable: "Queue",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Queue_QueueId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropIndex(
                name: "IX_Orders_QueueId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "QueueId",
                table: "Orders");
        }
    }
}
