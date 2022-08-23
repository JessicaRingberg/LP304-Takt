﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LP304_Takt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventStatus",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatus", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Mac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mac_lp31x = table.Column<int>(type: "int", nullable: false),
                    Mac_bidisp3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderAlarm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAlarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlarmTypeId = table.Column<int>(type: "int", nullable: false),
                    OrderAlarmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarm_AlarmType_AlarmTypeId",
                        column: x => x.AlarmTypeId,
                        principalTable: "AlarmType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alarm_OrderAlarm_OrderAlarmId",
                        column: x => x.OrderAlarmId,
                        principalTable: "OrderAlarm",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderEventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_OrderEvent_OrderEventId",
                        column: x => x.OrderEventId,
                        principalTable: "OrderEvent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LightsOn = table.Column<bool>(type: "bit", nullable: false),
                    SoundOn = table.Column<bool>(type: "bit", nullable: false),
                    FilterTime = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    MacId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Config_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Config_Mac_MacId",
                        column: x => x.MacId,
                        principalTable: "Mac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RunSetDec = table.Column<double>(type: "float", nullable: false),
                    ChangeSetDec = table.Column<double>(type: "float", nullable: false),
                    PartsProd = table.Column<int>(type: "int", nullable: false),
                    Backlog = table.Column<int>(type: "int", nullable: false),
                    RunSecSet = table.Column<int>(type: "int", nullable: false),
                    ChangeSetSec = table.Column<int>(type: "int", nullable: false),
                    TaktSet = table.Column<int>(type: "int", nullable: false),
                    LastPartProd = table.Column<int>(type: "int", nullable: false),
                    Takt = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    OrderAlarmId = table.Column<int>(type: "int", nullable: true),
                    OrderEventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderAlarm_OrderAlarmId",
                        column: x => x.OrderAlarmId,
                        principalTable: "OrderAlarm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_OrderEvent_OrderEventId",
                        column: x => x.OrderEventId,
                        principalTable: "OrderEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queue_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarm_AlarmTypeId",
                table: "Alarm",
                column: "AlarmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarm_OrderAlarmId",
                table: "Alarm",
                column: "OrderAlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CompanyId",
                table: "Area",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Config_AreaId",
                table: "Config",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Config_MacId",
                table: "Config",
                column: "MacId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrderEventId",
                table: "Event",
                column: "OrderEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderAlarmId",
                table: "Order",
                column: "OrderAlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderEventId",
                table: "Order",
                column: "OrderEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StationId",
                table: "Order",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Queue_OrderId",
                table: "Queue",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_AreaId",
                table: "Station",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarm");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventStatus");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AlarmType");

            migrationBuilder.DropTable(
                name: "Mac");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "OrderAlarm");

            migrationBuilder.DropTable(
                name: "OrderEvent");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
