using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class Dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "jacob.benett@gmail.com", "Jacob", "Benett", "123456" },
                    { 2, "vinay.gupta@gmail.com", "Vinay", "Gupta", "123456" },
                    { 3, "nicholas.henrikson@gmail.com", "Nicholas", "Henrikson", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Content", "CreatedDate", "LastUpdatedDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "I’ve used these features of Git for years across teams and projects. I’m still developing opinions around some workflows (like to squash or not) but the core tooling is powerful and flexible (and scriptable!).\r\n\r\nGoing through Git logs\r\nGit logs are gross to go through out of the box.\r\n\r\ngit log is basic\r\nUsing git log gives you some information. But it’s extremely high-resolution and not usually what you’re looking for.", new DateTime(2023, 7, 18, 12, 27, 53, 670, DateTimeKind.Local).AddTicks(2751), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Use Git like a senior engineer", 1 },
                    { 2, "When I started working with microservices, I took the common rule of “two services must not share a data source” a bit too literally.\r\n\r\nI saw it stapled everywhere on the internet: “thou shalt not share a DB between two services”, and it definitely made sense. A service must own its data and retain the freedom to change its schema as it pleases, without changing its external-facing API.\r\n\r\nBut there’s an important subtlety here that I didn’t understand until much later. To apply this rule properly, we have to distinguish between sharing a data source and sharing data.", new DateTime(2023, 7, 18, 12, 27, 53, 670, DateTimeKind.Local).AddTicks(2807), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharing Data Between Microservices", 2 },
                    { 3, "A friend of mine recently joined a FAANG company as an engineering manager, and found themselves in the position of recruiting for engineering candidates.\r\n\r\nWe caught up.\r\n\r\n“Well,” I laughed when they inquired about the possibility of me joining the team, “I’m not sure I’ll pass the interviews, but of course I’d love to work with you again! I’ll think about it.”\r\n\r\n“That’s the same thing X and Y both said,” they told me, referring to other engineers we had worked with together. “They both said they…\r\n\r\n", new DateTime(2023, 7, 18, 12, 27, 53, 670, DateTimeKind.Local).AddTicks(2811), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Why Experienced Programmers Fail Coding Interviews", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
