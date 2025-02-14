using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaManage_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addForeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "villaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "villaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate", "VillaID" },
                values: new object[] { new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5399), new DateTime(2025, 2, 14, 14, 56, 1, 842, DateTimeKind.Local).AddTicks(5400), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_villaNumbers_VillaID",
                table: "villaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_villaNumbers_Villas_VillaID",
                table: "villaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villaNumbers_Villas_VillaID",
                table: "villaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_villaNumbers_VillaID",
                table: "villaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "villaNumbers");

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

            migrationBuilder.UpdateData(
                table: "villaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(376), new DateTime(2025, 2, 14, 14, 36, 6, 53, DateTimeKind.Local).AddTicks(378) });
        }
    }
}
