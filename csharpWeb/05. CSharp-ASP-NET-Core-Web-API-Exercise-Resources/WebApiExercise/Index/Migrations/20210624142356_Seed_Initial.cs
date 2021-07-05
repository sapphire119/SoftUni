using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Index.Migrations
{
    public partial class Seed_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "CreatedOn", "User" },
                values: new object[,]
                {
                    { new Guid("e1496eac-178b-4b61-aca5-1aecd141ac1e"), "hey Pesho", new DateTime(2021, 6, 24, 17, 23, 56, 587, DateTimeKind.Local).AddTicks(6128), "gosho'" },
                    { new Guid("9f332bd2-fad5-4c16-8bef-f04e50034727"), "hey Gosho", new DateTime(2021, 6, 24, 17, 23, 56, 589, DateTimeKind.Local).AddTicks(3994), "pesho'" },
                    { new Guid("4fae6b97-83a6-4628-910e-3522058540b3"), "What's up?", new DateTime(2021, 6, 24, 17, 23, 56, 589, DateTimeKind.Local).AddTicks(4021), "gosho'" },
                    { new Guid("01f01d21-018e-4ddb-9a2b-c20352f1a8e1"), "Nothing", new DateTime(2021, 6, 24, 17, 23, 56, 589, DateTimeKind.Local).AddTicks(4026), "pesho'" },
                    { new Guid("25543851-b6ec-49e6-9e37-cf0eb3df4f2e"), "How are you?", new DateTime(2021, 6, 24, 17, 23, 56, 589, DateTimeKind.Local).AddTicks(4036), "gosho'" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
