using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpecificationDesignPattern.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MpaaRating = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });
            migrationBuilder.Sql(@"
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

GO
INSERT [dbo].[Movie] ([Id], [Name], [ReleaseDate], [MpaaRating], [Genre], [Rating]) VALUES (1, N'The Amazing Spider-Man', CAST(N'2012-07-03 00:00:00.000' AS DateTime), 3, N'Adventure', 7)
GO
INSERT [dbo].[Movie] ([Id], [Name], [ReleaseDate], [MpaaRating], [Genre], [Rating]) VALUES (2, N'Beauty and the Beast', CAST(N'2017-03-17 00:00:00.000' AS DateTime), 3, N'Family', 7.8)
GO
INSERT [dbo].[Movie] ([Id], [Name], [ReleaseDate], [MpaaRating], [Genre], [Rating]) VALUES (3, N'The Secret Life of Pets', CAST(N'2016-07-08 00:00:00.000' AS DateTime), 1, N'Adventure', 6.6)
GO
INSERT [dbo].[Movie] ([Id], [Name], [ReleaseDate], [MpaaRating], [Genre], [Rating]) VALUES (4, N'The Jungle Book', CAST(N'2016-04-15 00:00:00.000' AS DateTime), 2, N'Fantasy', 7.5)
GO
INSERT [dbo].[Movie] ([Id], [Name], [ReleaseDate], [MpaaRating], [Genre], [Rating]) VALUES (5, N'Split', CAST(N'2017-01-20 00:00:00.000' AS DateTime), 3, N'Horror', 7.4)
GO
INSERT [dbo].[Movie] ([Id], [Name], [ReleaseDate], [MpaaRating], [Genre], [Rating]) VALUES (6, N'The Mummy', CAST(N'2017-06-09 00:00:00.000' AS DateTime), 4, N'Action', 6.7)
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
