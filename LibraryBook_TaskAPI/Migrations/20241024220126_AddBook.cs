using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryBook_TaskAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "Thriller", 2003, "Fortune of Time" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "Action", 1980, "Dark Skies" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "Drama", 1993, "Vanish in the Sunset" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"));
        }
    }
}
