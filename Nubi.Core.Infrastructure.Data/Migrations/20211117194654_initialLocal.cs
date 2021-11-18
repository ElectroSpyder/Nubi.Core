using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nubi.Core.Infrastructure.Data.Migrations
{
    public partial class initialLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Apellido", "CreatedAt", "Email", "IsDeleted", "Nombre", "Password" },
                values: new object[,]
                {
                    { 1, "LastName1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.1@example.com", false, "FirstName1", "da2cb7f780b225403e5487ce7d40feaa0283f663ce05c7882df100110e8aae86" },
                    { 18, "LastName18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.18@example.com", false, "FirstName18", "7d46c9a102dd94082b0df0f06aa9b69256bec64f0c915ed34245235beaa673a1" },
                    { 17, "LastName17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.17@example.com", false, "FirstName17", "c83de05a9ad9c1166c2b7a44ad2c306fced3a2bed18474432086f864abd04571" },
                    { 16, "LastName16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.16@example.com", false, "FirstName16", "bb207afb4c102f15ae931f4b61c4ab41f91fec28a7eeca31f9be6032a9241a5e" },
                    { 15, "LastName15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.15@example.com", false, "FirstName15", "fefdbc0ad406198526298fa68616ab7590845ebb4b6610cd95b7d94fcb4a9327" },
                    { 14, "LastName14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.14@example.com", false, "FirstName14", "433469d27acfdac401ca6dccfa117f862f88ab196db90351a2d3a455f6425562" },
                    { 13, "LastName13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.13@example.com", false, "FirstName13", "5a2713bbbaf02b5ccd0ddefea7585bd00ac6433bb75d5ac8e33d4af9b0505b6e" },
                    { 12, "LastName12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.12@example.com", false, "FirstName12", "0d01e6313118ce3b9367556387930a3ebfdce61a629befacdf7afdad43245a8d" },
                    { 11, "LastName11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.11@example.com", false, "FirstName11", "e4d79a53b370e1c11e4b10905fa6325c524a1e9beb6a4612dbf72460da0325b2" },
                    { 10, "LastName10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.10@example.com", false, "FirstName10", "7562a64cdd0a4a1f7d9e77a50dcdc52ffe6a59db7d196293caa5e25a15a9e367" },
                    { 9, "LastName9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.9@example.com", false, "FirstName9", "343fb0969817815b1eb788c549b2a27601366b57ba383dc8ba46e39e64e5e6bf" },
                    { 8, "LastName8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.8@example.com", false, "FirstName8", "ce62fe20d866e1e69de326a4f01b7a92b1ee4f1a3df9ae6698196178900b1723" },
                    { 7, "LastName7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.7@example.com", false, "FirstName7", "83f164ce80cfaa93ece1883784d17c4d88451f76b07456cdc8af3020847fb56b" },
                    { 6, "LastName6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.6@example.com", false, "FirstName6", "7c7bc4898dcac630e60c547a30157d0b4ebf38a43b0ccb830d1660025cbc501f" },
                    { 5, "LastName5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.5@example.com", false, "FirstName5", "94137b5c6376f43518d5d158803e477fb33add3da1b4cf49bfa7ce57f09d4ad2" },
                    { 4, "LastName4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.4@example.com", false, "FirstName4", "3e3c9fc79e9983f129e8c2868087a366de92423d0fc9cfe39b4b43b9715b0fe6" },
                    { 3, "LastName3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.3@example.com", false, "FirstName3", "c02e7b0531c16cf9f95c1686fb9497c052aebe4ca9a3bf00fbc83c11245df53c" },
                    { 2, "LastName2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.2@example.com", false, "FirstName2", "e95a7a5547e515340590caa15cbaa99914f594f1398e24e9cfd5207fb66dc0ff" },
                    { 19, "LastName19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.19@example.com", false, "FirstName19", "462baa5d5c9865c59270375ad5bf4c5856372ddec84deefd9af2f15a03756142" },
                    { 20, "LastName20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.20@example.com", false, "FirstName20", "69ef1883caee50de909a3f11fda6937a483da453fd363467642982830570d2b8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
