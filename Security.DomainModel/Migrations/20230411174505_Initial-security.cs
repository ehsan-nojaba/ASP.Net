using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.DomainModel.Migrations
{
    public partial class Initialsecurity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectAreas",
                columns: table => new
                {
                    ProjectAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectAreaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAreas", x => x.ProjectAreaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectControllers",
                columns: table => new
                {
                    ProjectControllerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectAreaId = table.Column<int>(type: "int", nullable: false),
                    ProjectControllerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectControllers", x => x.ProjectControllerId);
                    table.ForeignKey(
                        name: "FK_ProjectControllers_ProjectAreas_ProjectAreaId",
                        column: x => x.ProjectAreaId,
                        principalTable: "ProjectAreas",
                        principalColumn: "ProjectAreaId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    isEmailActived = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectActions",
                columns: table => new
                {
                    ProjectActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectControllerId = table.Column<int>(type: "int", nullable: false),
                    ProjectActionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectActions", x => x.ProjectActionId);
                    table.ForeignKey(
                        name: "FK_ProjectActions_ProjectControllers_ProjectControllerId",
                        column: x => x.ProjectControllerId,
                        principalTable: "ProjectControllers",
                        principalColumn: "ProjectControllerId");
                });

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    RoleActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectActionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    HasPermission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.RoleActionId);
                    table.ForeignKey(
                        name: "FK_RoleActions_ProjectActions_ProjectActionId",
                        column: x => x.ProjectActionId,
                        principalTable: "ProjectActions",
                        principalColumn: "ProjectActionId");
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActions_ProjectControllerId",
                table: "ProjectActions",
                column: "ProjectControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectControllers_ProjectAreaId",
                table: "ProjectControllers",
                column: "ProjectAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_ProjectActionId",
                table: "RoleActions",
                column: "ProjectActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleId",
                table: "RoleActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProjectActions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ProjectControllers");

            migrationBuilder.DropTable(
                name: "ProjectAreas");
        }
    }
}
