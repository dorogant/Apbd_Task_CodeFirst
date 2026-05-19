using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apbd_Task_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditionalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 4, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices" },
                    { 5, "SSG", new DateOnly(1969, 1, 13), "Samsung Electronics" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 4, "SSD", "Solid State Drive" },
                    { 5, "MB", "Motherboard" }
                });

            migrationBuilder.UpdateData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM0000001", 3 },
                column: "Amount",
                value: 1);

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "RAM0000001", 1, 2 },
                    { "RAM0000001", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workstation", 3, 36, 11.4f },
                    { 5, new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creator PC", 7, 24, 7.6f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU0000002", 4, 1, "Processor", "Ryzen 7" },
                    { "GPU0000002", 4, 2, "Graphics card", "Radeon RX" },
                    { "MB00000001", 2, 5, "Motherboard", "Intel Board" },
                    { "SSD0000001", 5, 4, "Storage drive", "Samsung SSD" },
                    { "SSD0000002", 1, 4, "Storage drive", "Apple SSD" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "CPU0000001", 4, 2 },
                    { "GPU0000001", 5, 1 },
                    { "SSD0000001", 1, 1 },
                    { "CPU0000002", 2, 1 },
                    { "SSD0000001", 2, 1 },
                    { "SSD0000002", 3, 1 },
                    { "GPU0000002", 4, 2 },
                    { "MB00000001", 4, 1 },
                    { "CPU0000002", 5, 1 },
                    { "SSD0000001", 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM0000001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD0000001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "CPU0000002", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM0000001", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD0000001", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD0000002", 3 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "CPU0000001", 4 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "GPU0000002", 4 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "MB00000001", 4 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "CPU0000002", 5 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "GPU0000001", 5 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "SSD0000001", 5 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "CPU0000002");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "GPU0000002");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "MB00000001");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "SSD0000001");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "SSD0000002");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM0000001", 3 },
                column: "Amount",
                value: 2);
        }
    }
}
