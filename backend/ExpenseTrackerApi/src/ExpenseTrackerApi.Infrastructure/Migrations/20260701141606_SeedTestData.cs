using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTrackerApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDefault", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("cccccccc-0000-0000-0000-000000000001"), "#4CAF50", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Élelmiszer", null, null },
                    { new Guid("cccccccc-0000-0000-0000-000000000002"), "#2196F3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Közlekedés", null, null },
                    { new Guid("cccccccc-0000-0000-0000-000000000003"), "#9C27B0", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Szórakozás", null, null },
                    { new Guid("cccccccc-0000-0000-0000-000000000004"), "#F44336", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Számlák", null, null },
                    { new Guid("cccccccc-0000-0000-0000-000000000005"), "#FF9800", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Egészség", null, null },
                    { new Guid("cccccccc-0000-0000-0000-000000000006"), "#607D8B", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Egyéb", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PasswordHash", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "kiss.peter@example.com", "Nagy Tamás", "AQAAAAIAAYagAAAAEHashedPasswordPlaceholder1==", null },
                    { new Guid("aaaaaaaa-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "nagy.anna@example.com", "Kiss Anna", "AQAAAAIAAYagAAAAEHashedPasswordPlaceholder2==", null }
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LimitAmount", "Month", "UpdatedAt", "UserId", "Year" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000001"), new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000002"), new Guid("cccccccc-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000003"), new Guid("cccccccc-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000004"), new Guid("cccccccc-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000006"), new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000m, 6, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000007"), new Guid("cccccccc-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12000m, 6, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000008"), new Guid("cccccccc-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 25000m, 6, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0002-000000000001"), new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000002"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0002-000000000003"), new Guid("cccccccc-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000002"), 2026 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("cccccccc-0000-0000-0000-000000000007"), "#00BCD4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sport", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("cccccccc-0000-0000-0000-000000000008"), "#FF5722", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Utazás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "CreatedAt", "Date", "Description", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("eeeeeeee-0000-0000-0001-000000000001"), 12500m, new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Heti bevásárlás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000002"), 8300m, new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Piaci vásárlás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000003"), 9500m, new Guid("cccccccc-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Havi bérlet", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000004"), 4990m, new Guid("cccccccc-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Netflix előfizetés", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000005"), 22000m, new Guid("cccccccc-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Villanyszámla", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000006"), 6500m, new Guid("cccccccc-0000-0000-0000-000000000005"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Gyógyszerek", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000008"), 3200m, new Guid("cccccccc-0000-0000-0000-000000000006"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tollak, füzetek", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000009"), 14200m, new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Heti bevásárlás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000010"), 5600m, new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Étterem", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000011"), 9500m, new Guid("cccccccc-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Havi bérlet", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000012"), 4200m, new Guid("cccccccc-0000-0000-0000-000000000002"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Taxi", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000013"), 18500m, new Guid("cccccccc-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Gázszámla", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000014"), 12000m, new Guid("cccccccc-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Koncertjegy", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000001"), 9800m, new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Heti bevásárlás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000004"), 15000m, new Guid("cccccccc-0000-0000-0000-000000000005"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Fogorvos", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000005"), 19500m, new Guid("cccccccc-0000-0000-0000-000000000004"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Villanyszámla", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000006"), 11200m, new Guid("cccccccc-0000-0000-0000-000000000001"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Heti bevásárlás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000007"), 8900m, new Guid("cccccccc-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Mozi + vacsora", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000009"), 4500m, new Guid("cccccccc-0000-0000-0000-000000000006"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Könyvek", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "LimitAmount", "Month", "UpdatedAt", "UserId", "Year" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-0000-0000-0001-000000000005"), new Guid("cccccccc-0000-0000-0000-000000000007"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 20000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000001"), 2026 },
                    { new Guid("bbbbbbbb-0000-0000-0002-000000000002"), new Guid("cccccccc-0000-0000-0000-000000000008"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 30000m, 7, null, new Guid("aaaaaaaa-0000-0000-0000-000000000002"), 2026 }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "CategoryId", "CreatedAt", "Date", "Description", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("eeeeeeee-0000-0000-0001-000000000007"), 15000m, new Guid("cccccccc-0000-0000-0000-000000000007"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Edzőterem bérlet", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0001-000000000015"), 15000m, new Guid("cccccccc-0000-0000-0000-000000000007"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Edzőterem bérlet", null, new Guid("aaaaaaaa-0000-0000-0000-000000000001") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000002"), 85000m, new Guid("cccccccc-0000-0000-0000-000000000008"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Repülőjegy", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000003"), 42000m, new Guid("cccccccc-0000-0000-0000-000000000008"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Szállás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") },
                    { new Guid("eeeeeeee-0000-0000-0002-000000000008"), 32000m, new Guid("cccccccc-0000-0000-0000-000000000008"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Hétvégi kirándulás", null, new Guid("aaaaaaaa-0000-0000-0000-000000000002") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000006"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000007"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0001-000000000008"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-0000-0000-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000006"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000007"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000008"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000009"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000010"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000011"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000012"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000013"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000014"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0001-000000000015"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000004"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000005"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000006"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000007"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000008"));

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-0000-0000-0002-000000000009"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-0000-0000-0000-000000000002"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDefault", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "#4CAF50", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Élelmiszer", null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "#2196F3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Közlekedés", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "#9C27B0", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Szórakozás", null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "#F44336", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Számlák", null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "#FF9800", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Egészség", null, null },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "#607D8B", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Egyéb", null, null }
                });
        }
    }
}
