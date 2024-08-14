using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatePictureUrlProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicturUrl",
                table: "Product",
                newName: "PictureUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Product",
                newName: "PicturUrl");
        }
    }
}
