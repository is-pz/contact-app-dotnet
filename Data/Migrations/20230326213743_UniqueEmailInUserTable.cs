using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contact_app.Migrations
{
    /// <inheritdoc />
    public partial class UniqueEmailInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint("unique", "Users", "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
