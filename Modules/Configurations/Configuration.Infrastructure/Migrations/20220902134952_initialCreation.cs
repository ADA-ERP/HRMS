using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Configurations.Infrastructure.Migrations
{
    public partial class initialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "configuration");

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LogUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneTwo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISOCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfStudy",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyValues",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionChangeReasons",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionChangeReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStructure",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayBand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Minimum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Midpoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Maximum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Spread = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Range = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStructure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "configuration",
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobGrades",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfStudy = table.Column<int>(type: "int", nullable: false),
                    MinExperienceRequired = table.Column<double>(type: "float", nullable: false),
                    MaxExperienceRequired = table.Column<double>(type: "float", nullable: false),
                    SalaryStructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobGrades_SalaryStructure_SalaryStructureId",
                        column: x => x.SalaryStructureId,
                        principalSchema: "configuration",
                        principalTable: "SalaryStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    JobGradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_JobGrades_JobGradeId",
                        column: x => x.JobGradeId,
                        principalSchema: "configuration",
                        principalTable: "JobGrades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                schema: "configuration",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                schema: "configuration",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobGrades_SalaryStructureId",
                schema: "configuration",
                table: "JobGrades",
                column: "SalaryStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_JobGradeId",
                schema: "configuration",
                table: "Positions",
                column: "JobGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionCode",
                schema: "configuration",
                table: "Positions",
                column: "PositionCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "FieldOfStudy",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "KeyValues",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "PositionChangeReasons",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Titles",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "JobGrades",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "SalaryStructure",
                schema: "configuration");
        }
    }
}
