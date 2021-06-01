using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class TablesBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Company");

            migrationBuilder.EnsureSchema(
                name: "HumanResourse");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Company",
                columns: table => new
                {
                    DeptNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__0148CAAEE341BFEC", x => x.DeptNo);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Company",
                columns: table => new
                {
                    ProjectNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Project__761A861F927DD025", x => x.ProjectNo);
                });

            migrationBuilder.CreateTable(
                name: "Works_on",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    ProjectNo = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Enter_Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Works_on__484CCEB22C47FC51", x => new { x.EmpNo, x.ProjectNo });
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HumanResourse",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DeptNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__AF2D66D35DEDA9C4", x => x.EmpNo);
                    table.ForeignKey(
                        name: "FK__Employee__DeptNo__3B75D760",
                        column: x => x.DeptNo,
                        principalSchema: "Company",
                        principalTable: "Department",
                        principalColumn: "DeptNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptNo",
                schema: "HumanResourse",
                table: "Employee",
                column: "DeptNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HumanResourse");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "Works_on");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Company");
        }
    }
}
