using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "Set",
                columns: table => new
                {
                    SetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Weight = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set", x => x.SetId);
                    table.ForeignKey(
                        name: "FK_Set_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Set_ExerciseId",
                table: "Set",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Set");

            migrationBuilder.DropTable(
                name: "Exercise");
        }
    }
}
