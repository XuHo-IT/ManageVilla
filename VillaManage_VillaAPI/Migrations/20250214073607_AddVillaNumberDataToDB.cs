using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaManage_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.InsertData(
                table: "villaNumbers",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(376), "Nice one", new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(378) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 13, 40, 59, 288, DateTimeKind.Local).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 13, 40, 59, 288, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 13, 40, 59, 288, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 13, 40, 59, 288, DateTimeKind.Local).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 13, 40, 59, 288, DateTimeKind.Local).AddTicks(6894));
        }
    }
}
