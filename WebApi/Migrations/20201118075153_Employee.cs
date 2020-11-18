using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    dept_no = table.Column<Guid>(type: "uuid", nullable: false),
                    dept_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.dept_no);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    emp_no = table.Column<Guid>(type: "uuid", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<int>(type: "integer", nullable: false),
                    hire_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.emp_no);
                });

            migrationBuilder.CreateTable(
                name: "dept_emp",
                columns: table => new
                {
                    emp_no = table.Column<Guid>(type: "uuid", nullable: false),
                    dept_no = table.Column<Guid>(type: "uuid", nullable: false),
                    from_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    to_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept_emp", x => new { x.dept_no, x.emp_no });
                    table.ForeignKey(
                        name: "FK_dept_emp_departments_dept_no",
                        column: x => x.dept_no,
                        principalTable: "departments",
                        principalColumn: "dept_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dept_emp_employees_emp_no",
                        column: x => x.emp_no,
                        principalTable: "employees",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dept_manager",
                columns: table => new
                {
                    dept_no = table.Column<Guid>(type: "uuid", nullable: false),
                    emp_no = table.Column<Guid>(type: "uuid", nullable: false),
                    from_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    to_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EmployeeEmpNo = table.Column<Guid>(type: "uuid", nullable: true),
                    DepartmentDeptNo = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept_manager", x => new { x.dept_no, x.emp_no });
                    table.ForeignKey(
                        name: "FK_dept_manager_departments_DepartmentDeptNo",
                        column: x => x.DepartmentDeptNo,
                        principalTable: "departments",
                        principalColumn: "dept_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dept_manager_employees_EmployeeEmpNo",
                        column: x => x.EmployeeEmpNo,
                        principalTable: "employees",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    emp_no = table.Column<Guid>(type: "uuid", nullable: false),
                    from_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    to_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    salary = table.Column<double>(type: "double precision", nullable: false),
                    EmployeeEmpNo = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => new { x.emp_no, x.from_date, x.to_date });
                    table.ForeignKey(
                        name: "FK_salaries_employees_EmployeeEmpNo",
                        column: x => x.EmployeeEmpNo,
                        principalTable: "employees",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    emp_no = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    from_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    to_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EmployeeEmpNo = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => new { x.emp_no, x.title });
                    table.ForeignKey(
                        name: "FK_titles_employees_EmployeeEmpNo",
                        column: x => x.EmployeeEmpNo,
                        principalTable: "employees",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dept_emp_emp_no",
                table: "dept_emp",
                column: "emp_no");

            migrationBuilder.CreateIndex(
                name: "IX_dept_manager_DepartmentDeptNo",
                table: "dept_manager",
                column: "DepartmentDeptNo");

            migrationBuilder.CreateIndex(
                name: "IX_dept_manager_EmployeeEmpNo",
                table: "dept_manager",
                column: "EmployeeEmpNo");

            migrationBuilder.CreateIndex(
                name: "IX_salaries_EmployeeEmpNo",
                table: "salaries",
                column: "EmployeeEmpNo");

            migrationBuilder.CreateIndex(
                name: "IX_titles_EmployeeEmpNo",
                table: "titles",
                column: "EmployeeEmpNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dept_emp");

            migrationBuilder.DropTable(
                name: "dept_manager");

            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "titles");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
