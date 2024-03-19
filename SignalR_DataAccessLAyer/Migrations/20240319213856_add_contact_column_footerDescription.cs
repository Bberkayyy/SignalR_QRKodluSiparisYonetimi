using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR_DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_contact_column_footerDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterDescription",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterDescription",
                table: "Contacts");
        }
    }
}
