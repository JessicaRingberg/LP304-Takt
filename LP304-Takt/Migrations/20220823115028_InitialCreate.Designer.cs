﻿// <auto-generated />
using System;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LP304_Takt.Migrations
{
    [DbContext(typeof(LP304Context))]
    [Migration("20220823115028_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LP304_Takt.Models.Alarm", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AlarmTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderAlarmId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlarmTypeId");

                    b.HasIndex("OrderAlarmId");

                    b.ToTable("Alarm");
                });

            modelBuilder.Entity("LP304_Takt.Models.AlarmType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlarmType");
                });

            modelBuilder.Entity("LP304_Takt.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("LP304_Takt.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("LP304_Takt.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("FilterTime")
                        .HasColumnType("int");

                    b.Property<bool>("LightsOn")
                        .HasColumnType("bit");

                    b.Property<int>("MacId")
                        .HasColumnType("int");

                    b.Property<bool>("SoundOn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("MacId");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("LP304_Takt.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderEventId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderEventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("LP304_Takt.Models.EventStatus", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("EventStatus");
                });

            modelBuilder.Entity("LP304_Takt.Models.Mac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Mac_bidisp3")
                        .HasColumnType("int");

                    b.Property<int>("Mac_lp31x")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mac");
                });

            modelBuilder.Entity("LP304_Takt.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Backlog")
                        .HasColumnType("int");

                    b.Property<double>("ChangeSetDec")
                        .HasColumnType("float");

                    b.Property<int>("ChangeSetSec")
                        .HasColumnType("int");

                    b.Property<int>("LastPartProd")
                        .HasColumnType("int");

                    b.Property<int?>("OrderAlarmId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderEventId")
                        .HasColumnType("int");

                    b.Property<int>("PartsProd")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RunSecSet")
                        .HasColumnType("int");

                    b.Property<double>("RunSetDec")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<int>("Takt")
                        .HasColumnType("int");

                    b.Property<int>("TaktSet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderAlarmId");

                    b.HasIndex("OrderEventId");

                    b.HasIndex("StationId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("LP304_Takt.Models.OrderAlarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("OrderAlarm");
                });

            modelBuilder.Entity("LP304_Takt.Models.OrderEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("OrderEvent");
                });

            modelBuilder.Entity("LP304_Takt.Models.Queue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Queue");
                });

            modelBuilder.Entity("LP304_Takt.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LP304_Takt.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("LP304_Takt.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LP304_Takt.Models.Alarm", b =>
                {
                    b.HasOne("LP304_Takt.Models.AlarmType", "AlarmType")
                        .WithMany()
                        .HasForeignKey("AlarmTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LP304_Takt.Models.OrderAlarm", null)
                        .WithMany("AlarmId")
                        .HasForeignKey("OrderAlarmId");

                    b.Navigation("AlarmType");
                });

            modelBuilder.Entity("LP304_Takt.Models.Area", b =>
                {
                    b.HasOne("LP304_Takt.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LP304_Takt.Models.Config", b =>
                {
                    b.HasOne("LP304_Takt.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LP304_Takt.Models.Mac", "Mac")
                        .WithMany()
                        .HasForeignKey("MacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Mac");
                });

            modelBuilder.Entity("LP304_Takt.Models.Event", b =>
                {
                    b.HasOne("LP304_Takt.Models.OrderEvent", null)
                        .WithMany("EventId")
                        .HasForeignKey("OrderEventId");
                });

            modelBuilder.Entity("LP304_Takt.Models.Order", b =>
                {
                    b.HasOne("LP304_Takt.Models.OrderAlarm", null)
                        .WithMany("OrderId")
                        .HasForeignKey("OrderAlarmId");

                    b.HasOne("LP304_Takt.Models.OrderEvent", null)
                        .WithMany("OrderId")
                        .HasForeignKey("OrderEventId");

                    b.HasOne("LP304_Takt.Models.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("LP304_Takt.Models.Queue", b =>
                {
                    b.HasOne("LP304_Takt.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("LP304_Takt.Models.Station", b =>
                {
                    b.HasOne("LP304_Takt.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("LP304_Takt.Models.User", b =>
                {
                    b.HasOne("LP304_Takt.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LP304_Takt.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LP304_Takt.Models.OrderAlarm", b =>
                {
                    b.Navigation("AlarmId");

                    b.Navigation("OrderId");
                });

            modelBuilder.Entity("LP304_Takt.Models.OrderEvent", b =>
                {
                    b.Navigation("EventId");

                    b.Navigation("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
