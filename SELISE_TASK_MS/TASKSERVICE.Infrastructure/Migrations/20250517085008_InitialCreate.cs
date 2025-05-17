using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASKSERVICE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRACTICE_TASKS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ASSIGNED_TO_USER_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    CREATED_BY_USER_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    TEAM_ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRACTICE_TASKS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRACTICE_TASKS");
        }
    }
}
