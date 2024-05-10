using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_candidate_hub_API.Migrations
{
    /// <inheritdoc />
    public partial class CandidateHubDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeInterval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedInProfileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubProfileURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreeTextComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Email", "FirstName", "FreeTextComment", "GitHubProfileURL", "LastName", "LinkedInProfileURL", "PhoneNumber", "TimeInterval" },
                values: new object[] { "moustafafouda17@gmail.com", "Mustafa", "I am a Software Engineer at Network International", "github.com/MustafaFouda10", "Fouda", "linkedin.com/in/mustafa-fouda-/", "+201206670459", "1 hour" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
