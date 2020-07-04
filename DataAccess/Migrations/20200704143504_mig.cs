using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "OrderNumbers",
                startValue: 4L);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LogTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "nextval('\"OrderNumbers\"')"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DealerName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 7, 4, 17, 35, 4, 57, DateTimeKind.Local).AddTicks(782), "Login" },
                    { 2, 1, new DateTime(2020, 7, 4, 17, 35, 4, 57, DateTimeKind.Local).AddTicks(1392), "SendMail" },
                    { 3, 1, new DateTime(2020, 7, 4, 17, 35, 4, 57, DateTimeKind.Local).AddTicks(1409), "SendSMS" },
                    { 4, 1, new DateTime(2020, 7, 4, 17, 35, 4, 57, DateTimeKind.Local).AddTicks(1411), "DownloadPdf" },
                    { 5, 1, new DateTime(2020, 7, 4, 17, 35, 4, 57, DateTimeKind.Local).AddTicks(1414), "ChangePhone" },
                    { 6, 1, new DateTime(2020, 7, 4, 17, 35, 4, 57, DateTimeKind.Local).AddTicks(1415), "Error" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 7, 4, 17, 35, 4, 50, DateTimeKind.Local).AddTicks(3234), "Dealer" },
                    { 2, 2, new DateTime(2020, 7, 4, 17, 35, 4, 54, DateTimeKind.Local).AddTicks(7126), "CallCenterAdmin" },
                    { 3, 2, new DateTime(2020, 7, 4, 17, 35, 4, 54, DateTimeKind.Local).AddTicks(7179), "SporToto" },
                    { 4, 2, new DateTime(2020, 7, 4, 17, 35, 4, 54, DateTimeKind.Local).AddTicks(7181), "CallCenter" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreatedDate", "DealerId", "DealerName", "Email", "FullName", "IsActive", "Password", "Phone", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Test mah. Test sokak.", "İstanbul", 1, new DateTime(2020, 7, 4, 17, 35, 4, 56, DateTimeKind.Local).AddTicks(6363), 123123, "iddaa Bayisi", null, "Test", true, "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195", "5552223355", 1, 1, new DateTime(2020, 7, 4, 17, 35, 4, 56, DateTimeKind.Local).AddTicks(5732) },
                    { 2, null, null, 1, new DateTime(2020, 7, 4, 17, 35, 4, 56, DateTimeKind.Local).AddTicks(9742), null, null, null, "Çağrı Merkezi Admin", true, "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195", null, 2, 1, new DateTime(2020, 7, 4, 17, 35, 4, 56, DateTimeKind.Local).AddTicks(9725) },
                    { 3, "Test mah. Test sokak.", "İstanbul", 1, new DateTime(2020, 7, 4, 17, 35, 4, 56, DateTimeKind.Local).AddTicks(9784), 3, "SporToto Ekranı", null, "SporToto", true, "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195", "5552223355", 3, 1, new DateTime(2020, 7, 4, 17, 35, 4, 56, DateTimeKind.Local).AddTicks(9782) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "OrderNumbers");
        }
    }
}
