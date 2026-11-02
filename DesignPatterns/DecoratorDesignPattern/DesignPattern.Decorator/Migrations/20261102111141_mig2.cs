using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignPattern.Decorator.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifiers",
                columns: table => new
                {
                    NotifierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotifierCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotifierSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotifierType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotifierChannel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifiers", x => x.NotifierID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifiers");
        }
    }
}
