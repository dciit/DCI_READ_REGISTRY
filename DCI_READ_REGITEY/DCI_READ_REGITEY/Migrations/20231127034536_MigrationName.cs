using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DCI_READ_REGITEY.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCI_FIXED_ASSET_LOG",
                columns: table => new
                {
                    COMPUTER_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    REGISTRY_KEY = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    REGISTRY_VALUE = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCI_FIXED_ASSET_LOG", x => new { x.COMPUTER_NAME, x.REGISTRY_KEY, x.REGISTRY_VALUE });
                });

            migrationBuilder.CreateTable(
                name: "DCI_FIXED_ASSET_SETTING",
                columns: table => new
                {
                    HKEY = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    APP_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    KEY_OF_PATH = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    INSERT_DT = table.Column<DateTime>(type: "datetime", nullable: false),
                    INSERT_BY = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
                    FIXED_STATUS = table.Column<int>(nullable: true, defaultValueSql: "((0))", comment: "0 = ไม่ต้องทำการอัพเดรตข้อมูล 1 = อัพเดรตข้อมูล")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCI_FIXED_ASSET", x => new { x.HKEY, x.APP_PATH, x.KEY_OF_PATH });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCI_FIXED_ASSET_LOG");

            migrationBuilder.DropTable(
                name: "DCI_FIXED_ASSET_SETTING");
        }
    }
}
