using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interview_Schedule_Management.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AD_Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD_Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AD_ID);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    APP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APP_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APP_C_ID = table.Column<int>(type: "int", nullable: false),
                    APP_EXP = table.Column<int>(type: "int", nullable: false),
                    APP_REFF_ID = table.Column<int>(type: "int", nullable: false),
                    APP_QUALI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APP_INT_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INT_STAT = table.Column<bool>(type: "bit", nullable: false),
                    INT_HR_MARKS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.APP_ID);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    C_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_FNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_LNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_GENDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_PHONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_AGENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.C_ID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JOB_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HR_ID = table.Column<int>(type: "int", nullable: false),
                    REQ_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REQ_VAC = table.Column<int>(type: "int", nullable: false),
                    REQ_EXP = table.Column<int>(type: "int", nullable: false),
                    DOMAIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CLOSING_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRIORITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INT_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JOB_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
