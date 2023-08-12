using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShopStudio.Infrastructure.Migrations
{
    public partial class PartAndServiceAddedToOpCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "OperatingCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "OperatingCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5878fada-aeab-4d5f-9988-33391e8c3eb0", "AQAAAAEAACcQAAAAEKg2Q8si+Z/6VeJYLtqg4lAe8qOa9hGQJmLZCgAPvLv8ZR6F+xJHmbk1LILkzExTAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c35aefcd-4868-4521-b847-43c2ffdd5f24", "AQAAAAEAACcQAAAAEGOCXPNTjii4efX2qaz5Z1XuRttw7Ze0sY/ns/xKOviVer5SFXTZuTqnMz2qqdG+aw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e54fccde-0984-45e7-bd1a-14bebfcded6f", "AQAAAAEAACcQAAAAELYqdcNgmbE8aU8up16cUOhliyMY8iutF8aLSy0Bi+g/0zPFGPsf6ZsXJsetARdA8g==" });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DocumentNumber", "PartId", "ServiceId" },
                values: new object[] { "B5466HA12/6/2022 12:00:00 AM", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_PartId",
                table: "OperatingCards",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingCards_ServiceId",
                table: "OperatingCards",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingCards_Parts_PartId",
                table: "OperatingCards",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingCards_ShopServices_ServiceId",
                table: "OperatingCards",
                column: "ServiceId",
                principalTable: "ShopServices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatingCards_Parts_PartId",
                table: "OperatingCards");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatingCards_ShopServices_ServiceId",
                table: "OperatingCards");

            migrationBuilder.DropIndex(
                name: "IX_OperatingCards_PartId",
                table: "OperatingCards");

            migrationBuilder.DropIndex(
                name: "IX_OperatingCards_ServiceId",
                table: "OperatingCards");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "OperatingCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "OperatingCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71d9e096-281e-428d-85a0-e8fa800a7f65", "AQAAAAEAACcQAAAAEEMlOaY0AHtIHDrmo040H77rvrYCAM6dyNy1JrU2LyVVEcGLM21CkqaaaX2ZD9Sa4w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95cb6e27-a9c5-4d09-ae2e-e54370a14ac8", "AQAAAAEAACcQAAAAEBu3bl1NakP25uHGEQS3/CyCtbfU62N5axnYuD5zM4p9Wm40on1lDYjVIQ/AOt4x4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb78c1ab-c0f8-4cc3-a9e1-66ad6edc325f", "AQAAAAEAACcQAAAAEE4/v/2mtFqYh4DTo5L5R4C2r6I+OW6d8zGsfgNhgc6It1O5zE78brG2WLRtfDkMMQ==" });

            migrationBuilder.UpdateData(
                table: "OperatingCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DocumentNumber", "PartId", "ServiceId" },
                values: new object[] { "000112/6/2022 12:00:00 AM", 0, 0 });
        }
    }
}
