using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskProject.Migrations
{
    /// <inheritdoc />
    public partial class initilizerMegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assignee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Not Started" },
                    { 2, " In Progress" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Assignee", "Description", "DueDate", "StatusID", "Title" },
                values: new object[,]
                {
                    { 1, "isamil.sudani2022@gmail.com", " Description of firt task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2114), 1, " first task title" },
                    { 2, "isamil.sudani2022@gmail.com", " Description of second task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2131), 1, "  second task title" },
                    { 3, "isamil.sudani2022@gmail.com", " Description of third task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2133), 1, " third task title" },
                    { 4, "isamil.sudani2022@gmail.com", " Description of fourth task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2134), 1, " fourth task title" },
                    { 5, "isamil.sudani2022@gmail.com", " Description of Fifth task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2135), 1, " Fifth task title" },
                    { 6, "isamil.sudani2022@gmail.com", " Description of Sixth task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2136), 1, " Sixth task title" },
                    { 7, "isamil.sudani2022@gmail.com", " Description of Seventh task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2138), 1, " Seventh task title" },
                    { 8, "isamil.sudani2022@gmail.com", " Description of Eighth task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2139), 1, " Eighth task title" },
                    { 9, "isamil.sudani2022@gmail.com", " Description of Ninth task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2140), 1, " Ninth task title" },
                    { 10, "isamil.sudani2022@gmail.com", " Description of tenth task is here ", new DateTime(2024, 1, 18, 10, 29, 6, 229, DateTimeKind.Local).AddTicks(2141), 1, " tenth task title" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusID",
                table: "Tasks",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
