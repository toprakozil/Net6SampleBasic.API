using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net6SampleBasic.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationTag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccessionRecord = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "LocationTag", "Name" },
                values: new object[] { new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), "34-A", "locationA" });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "LocationTag", "Name" },
                values: new object[] { new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), "18-H", "locationB" });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "LocationTag", "Name" },
                values: new object[] { new Guid("d097a599-4619-4473-ae86-d353c3069597"), "1-B", "locationB" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AccessionRecord", "Category", "Description", "InventoryId", "Value" },
                values: new object[,]
                {
                    { new Guid("270ed53a-053b-442a-9302-716959d0a51a"), new DateTimeOffset(new DateTime(2016, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 3, 0, 0, 0)), "Office Supplies", "Desk", new Guid("d097a599-4619-4473-ae86-d353c3069597"), 10m },
                    { new Guid("3675f42d-9bbb-488f-bd36-c7e6411c87d5"), new DateTimeOffset(new DateTime(2015, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(219), new TimeSpan(0, 3, 0, 0, 0)), "Electronic", "ComputerA", new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), 10m },
                    { new Guid("4fa3169e-0779-45cc-9139-dc4ee92cbd5f"), new DateTimeOffset(new DateTime(2016, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 3, 0, 0, 0)), "Mechanic", "Ordinary Machine", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), 10m },
                    { new Guid("6978cc16-5f5a-4020-bb79-4cc4dcc36b72"), new DateTimeOffset(new DateTime(2019, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(188), new TimeSpan(0, 3, 0, 0, 0)), "Mechanic", "Fancy Machine", new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"), 10m },
                    { new Guid("b1ee8f72-0cc0-4cd9-bcc6-11183cf24da8"), new DateTimeOffset(new DateTime(2016, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 3, 0, 0, 0)), "Office Supplies", "Chair", new Guid("d097a599-4619-4473-ae86-d353c3069597"), 10m },
                    { new Guid("ea3a236e-fda4-4e3f-ae1d-3bd3a535a177"), new DateTimeOffset(new DateTime(2020, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 3, 0, 0, 0)), "Electronic", "ComputerB", new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"), 10m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryId",
                table: "Items",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
