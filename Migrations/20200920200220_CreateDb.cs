using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleListApi.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"), "Electronics" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b90cfb66-06eb-416e-a8eb-4e78fbf3ecb7"), "Clothing" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"), "Kitchen" });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("1355a30f-e2d9-47fb-85f0-ab33bfb0d1e2"), new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"), "TV", 2000m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("574d69e3-0571-4273-8128-71b2f1e30a4d"), new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"), "Playstation", 400m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("5a666b42-0736-40a2-a3f7-372daec8da01"), new Guid("1636d3c8-fc9e-4f5d-a8ee-80c1c44509f4"), "Stereo", 1600m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("d644804f-26bf-4b33-8f92-6e8d912bfae0"), new Guid("b90cfb66-06eb-416e-a8eb-4e78fbf3ecb7"), "Shirts", 1100m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("9364175f-9f25-4ed6-89da-0668e2f5fe3e"), new Guid("b90cfb66-06eb-416e-a8eb-4e78fbf3ecb7"), "Jeans", 1100m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("b8573bc1-349f-47bc-a052-e50eef1d9b95"), new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"), "Pots and Pans", 3000m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("1a1f26ab-11f2-4b1d-9ba4-917b9740fa81"), new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"), "Flatware", 500m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("db62b4a5-9ced-46be-aeb6-4ddff612a6c4"), new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"), "Knife Set", 500m });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { new Guid("c11da0e2-6b98-496c-aead-d75a6019d650"), new Guid("8e8cc99a-6a2c-485e-a33d-bbdecb948e03"), "Mics", 1000m });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_CategoryId",
                table: "LineItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
