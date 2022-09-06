using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LP304_Takt.Migrations
{
    public partial class Initialee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventStatusId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlarmTypeId",
                table: "Alarms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlarmTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventStatusId",
                table: "Events",
                column: "EventStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_AlarmTypeId",
                table: "Alarms",
                column: "AlarmTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_AlarmTypes_AlarmTypeId",
                table: "Alarms",
                column: "AlarmTypeId",
                principalTable: "AlarmTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatuses_EventStatusId",
                table: "Events",
                column: "EventStatusId",
                principalTable: "EventStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_AlarmTypes_AlarmTypeId",
                table: "Alarms");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatuses_EventStatusId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "AlarmTypes");

            migrationBuilder.DropTable(
                name: "EventStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventStatusId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Alarms_AlarmTypeId",
                table: "Alarms");

            migrationBuilder.DropColumn(
                name: "EventStatusId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AlarmTypeId",
                table: "Alarms");
        }
    }
}
