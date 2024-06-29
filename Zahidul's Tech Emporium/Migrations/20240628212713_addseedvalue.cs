using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zahidul_s_Tech_Emporium.Migrations
{
    /// <inheritdoc />
    public partial class addseedvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Lenovo Ideapad 3 with a 14\" FHD display, powered by an Intel Core i5-1035G1, 8GB RAM, 512GB SSD, and Windows 10. Perfect for everyday use.", "\\images\\product\\5fe718e2-864e-480f-9f4b-92f36a54eda3.webp", "Lenovo Ideapad 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Portable Dell laptop with efficient performance for work and study. Compact design, lightweight, and perfect for use on the go.", "\\images\\product\\533494b8-e34d-49b5-8f4e-f06a3912a369.jpeg", "Dell Inspiron 5055" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Lenovo ThinkPad T14 Gen 3, featuring a 14” WUXGA display, Intel i5-1235U, 16GB RAM, 512GB SSD, and Windows 11 Pro. Ideal for business professionals.", "\\images\\product\\3d30b5dc-d3fc-4e85-8185-f8ff7d9472a8.webp", "Lenovo ThinkPad T14 Gen 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Lenovo laptop, designed for portability and everyday tasks. Lightweight and easy to carry, making it a great choice for students.", "\\images\\product\\6f394ca7-4a38-4daa-a75f-2ca7a40c0bd4.webp", "Lenovo Slim 4544" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Affordable Lenovo laptop, perfect for basic computing needs. Compact and lightweight, suitable for students and home users.", "Lenovo Basic 4545" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "HP 100s laptop with a sleek design, great for productivity and entertainment. Portable and equipped with essential features for everyday use.", "\\images\\product\\0eb61fcd-0d70-42a9-baca-b8be1ae5a3e7.jpeg", "HP Pavilion 100s" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Compact and lightweight HP laptop, ideal for everyday tasks and web browsing. A great companion for users on the move.", "\\images\\product\\6fca5a19-6989-457d-94bd-8936dd45c1b7.jpeg", "HP Stream sd555" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Canon camera with advanced features, perfect for photography enthusiasts. Capture stunning images with ease.", "\\images\\product\\97a286c0-b68f-4abd-8312-dd0ff65a7a86.jpg", "Canon EOS 525545" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "High-end Canon camera designed for professional photographers. Delivers exceptional image quality and performance.", "\\images\\product\\349dfcc7-783e-495d-9521-fdbfe3c9cadc.jpg", "Canon PowerShot s333" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Suprima CCTV system for enhanced security. Reliable and easy to install, suitable for home and business surveillance.", "\\images\\product\\b545a9c6-3192-4e0f-a6cb-1fa2ac95925a.webp", "Suprima Secure n33" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Compact and efficient Suprima CCTV system for monitoring and security. Provides clear video footage for peace of mind.", "\\images\\product\\4709384e-6e4b-441a-9735-8d3a52bcfadf.webp", "Suprima Vision k33" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Vivo 3sT CCTV camera, designed for effective surveillance. Easy to install and operate, ideal for home security.", "VivoTech Guardian 3sT" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Lenovo Ideapad 3 14\" FHD PC Laptop, Intel Core i5-1035G1, 8GB RAM, 512GB SSD, Windows 10, Platinum Grey, 81WD00U9US", "5fe718e2-864e-480f-9f4b-92f36a54eda3.webp", "Lenovo Ideapad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Laptops are designed to be portable computers. They are smaller and lighter than desktops. The name connotes the user's ability to put the computer in their lap while they use it. ", "533494b8-e34d-49b5-8f4e-f06a3912a369.jpeg", "Dell 5055" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Lenovo ThinkPad T14 Gen 3 | 2022 Model | 14” WUXGA Display Laptop Black ( i5-1235U, 16GB, 512GB SSD, Intel, W11P )", "3d30b5dc-d3fc-4e85-8185-f8ff7d9472a8.webp", "Lenovo ThinkPad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Laptops are designed to be portable computers. They are smaller and lighter than desktops. The name connotes the user's ability to put the computer in their lap while they use it. ", "6f394ca7-4a38-4daa-a75f-2ca7a40c0bd4.webp", "Lenovo 4544" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Laptops are designed to be portable computers. They are smaller and lighter than desktops. The name connotes the user's ability to put the computer in their lap while they use it. ", "Lenovo 4545" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Laptops are designed to be portable computers. They are smaller and lighter than desktops. The name connotes the user's ability to put the computer in their lap while they use it. ", "0eb61fcd-0d70-42a9-baca-b8be1ae5a3e7.jpeg", "HP 100s" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Laptops are designed to be portable computers. They are smaller and lighter than desktops. The name connotes the user's ability to put the computer in their lap while they use it. ", "6fca5a19-6989-457d-94bd-8936dd45c1b7.jpeg", "HP sd555" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Campaign for Real Ale (CAMRA) is an independent voluntary consumer organisation headquartered in St Albans, England, which promotes real ale, cider and perry and traditional British pubs and clubs.", "97a286c0-b68f-4abd-8312-dd0ff65a7a86.jpg", "Canon 525545" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "The Campaign for Real Ale (CAMRA) is an independent voluntary consumer organisation headquartered in St Albans, England, which promotes real ale, cider and perry and traditional British pubs and clubs.", "349dfcc7-783e-495d-9521-fdbfe3c9cadc.jpg", "Canon s333" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "CCTV (closed-circuit television) is a TV system in which signals are not publicly distributed but are monitored, primarily for surveillance and security purposes. ", "b545a9c6-3192-4e0f-a6cb-1fa2ac95925a.webp", "Suprima n33" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "CCTV (closed-circuit television) is a TV system in which signals are not publicly distributed but are monitored, primarily for surveillance and security purposes. ", "4709384e-6e4b-441a-9735-8d3a52bcfadf.webp", "Suprima k33" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Title" },
                values: new object[] { "CCTV (closed-circuit television) is a TV system in which signals are not publicly distributed but are monitored, primarily for surveillance and security purposes. ", "Vivo 3sT" });
        }
    }
}
