using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ProjectAlliance.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    companyName = table.Column<string>(maxLength: 30, nullable: true),
                    createdBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectTitle = table.Column<string>(nullable: true),
                    projectDescription = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    progress = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(type: "Date", nullable: false),
                    companyProject = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(type: "Date", nullable: false),
                    endDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTeams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pid = table.Column<int>(nullable: false),
                    uid = table.Column<int>(nullable: false),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubTasks",
                columns: table => new
                {
                    taskid = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    taskTitle = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(type: "Date", nullable: false),
                    endDate = table.Column<DateTime>(type: "Date", nullable: false),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    progress = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTasks", x => x.taskid);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TaskTitle = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(type: "Date", nullable: false),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    progress = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(type: "Date", nullable: false),
                    TaskCost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.tid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 30, nullable: true),
                    password = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    profilePic = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    Lastlogin = table.Column<DateTime>(type: "Date", nullable: false),
                    role = table.Column<string>(nullable: true),
                    onlineStatus = table.Column<string>(nullable: true),
                    companyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectTeams");

            migrationBuilder.DropTable(
                name: "SubTasks");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
