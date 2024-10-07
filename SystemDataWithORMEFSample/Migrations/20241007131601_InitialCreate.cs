using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemDataWithORMEFSample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            // Create records for to be read
            migrationBuilder.Sql(
                "INSERT INTO Customer(Id, Name) Values(1, 'Alex Pimenta')"
                );

            migrationBuilder.Sql(
                "INSERT INTO Customer(Id, Name) Values(2, 'Arthur Gregorio Pimenta')"
                );

            migrationBuilder.Sql(
                "INSERT INTO Customer(Id, Name) Values(3, 'Estela Gregorio Pimenta')"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
