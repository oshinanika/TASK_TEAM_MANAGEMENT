using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USERSERVICE.InfrastructureDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SELISE_USERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    FULLNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PASSWORD_HASH = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    ROLE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SELISE_USERS", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "SELISE_USERS",
                columns: new[] { "ID", "EMAIL", "FULLNAME", "PASSWORD_HASH", "ROLE" },
                values: new object[,]
                {
                    { new Guid("38603a1b-8b8d-4305-83bf-c0b1bd83bed6"), "manager@demo.com", "Manager User", "$2a$11$uWfSc5TU0z2U5BYb5H.DUOACrijkRabHxV1IjxNu6LEquIB7C5/DW", "Manager" },
                    { new Guid("780516b4-851e-457e-9786-542f69de070b"), "employee@demo.com", "Employee User", "$2a$11$3aebbEQpGuBcj0Q08.RNn.avs/d0ILcU2r6n/BXaneaAkKPMoR0ku", "Employee" },
                    { new Guid("e492bcad-e565-44e7-a48f-a0759783da98"), "admin@demo.com", "Admin User", "$2a$11$OGnuVANAu5j7DAaJYqMNYegDrPQT4HkH0z5JrOhxdCbGTV9jL4kG6", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SELISE_USERS");
        }
    }
}
