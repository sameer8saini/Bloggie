using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    public partial class Addingnormalizedusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c052ffb4-245b-4c3c-8390-f1bd806828e2",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29c917e9-246b-49d9-9976-1d1d20917ddb", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAEAACcQAAAAEFaf/xGcHM+mbb2U2WoTMSngbNyywsabDQO5zzXXeejLC5blOfOj9+M8GiTsWL3Hcg==", "77b1083a-ff35-47d1-bf5d-a9578bb152c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c052ffb4-245b-4c3c-8390-f1bd806828e2",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a7799da-c6bd-4a50-9745-dde77d347544", null, null, "AQAAAAEAACcQAAAAEGG4O0SOdx3nK+krRKLx34OFL0+4Zk3yAXYW0bu9eTvrZVNbZ2hajOVliAqanVwjvQ==", "d44c6314-d38c-4650-8a2a-28afb9a538ac" });
        }
    }
}
