using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.DAL
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        //public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        //public DbSet<OrderHeader> OrderHeaders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Laptop", DisplayOrder = 1 },
                new Category { Id = 2, Name = "CCTV", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Camera", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, Title = "Lenovo Ideapad 3", Brand = "Lenovo", Description = "Lenovo Ideapad 3 with a 14\" FHD display, powered by an Intel Core i5-1035G1, 8GB RAM, 512GB SSD, and Windows 10. Perfect for everyday use.", Price = 69000, CategoryId = 1, ImageUrl = @"\images\product\5fe718e2-864e-480f-9f4b-92f36a54eda3.webp" },
    new Product { Id = 2, Title = "Dell Inspiron 5055", Brand = "DELL", Description = "Portable Dell laptop with efficient performance for work and study. Compact design, lightweight, and perfect for use on the go.", Price = 50000, CategoryId = 1, ImageUrl = @"\images\product\533494b8-e34d-49b5-8f4e-f06a3912a369.jpeg" },
    new Product { Id = 3, Title = "Lenovo ThinkPad T14 Gen 3", Brand = "Lenovo", Description = "Lenovo ThinkPad T14 Gen 3, featuring a 14” WUXGA display, Intel i5-1235U, 16GB RAM, 512GB SSD, and Windows 11 Pro. Ideal for business professionals.", Price = 160000, CategoryId = 1, ImageUrl = @"\images\product\3d30b5dc-d3fc-4e85-8185-f8ff7d9472a8.webp" },
    new Product { Id = 4, Title = "Lenovo Slim 4544", Brand = "Lenovo", Description = "Lenovo laptop, designed for portability and everyday tasks. Lightweight and easy to carry, making it a great choice for students.", Price = 45000, CategoryId = 1, ImageUrl = @"\images\product\6f394ca7-4a38-4daa-a75f-2ca7a40c0bd4.webp" },
    new Product { Id = 5, Title = "Lenovo Basic 4545", Brand = "Lenovo", Description = "Affordable Lenovo laptop, perfect for basic computing needs. Compact and lightweight, suitable for students and home users.", Price = 40000, CategoryId = 1, ImageUrl = @"" },
    new Product { Id = 6, Title = "HP Pavilion 100s", Brand = "HP", Description = "HP 100s laptop with a sleek design, great for productivity and entertainment. Portable and equipped with essential features for everyday use.", Price = 66000, CategoryId = 1, ImageUrl = @"\images\product\0eb61fcd-0d70-42a9-baca-b8be1ae5a3e7.jpeg" },
    new Product { Id = 7, Title = "HP Stream sd555", Brand = "HP", Description = "Compact and lightweight HP laptop, ideal for everyday tasks and web browsing. A great companion for users on the move.", Price = 40000, CategoryId = 1, ImageUrl = @"\images\product\6fca5a19-6989-457d-94bd-8936dd45c1b7.jpeg" },
    new Product { Id = 8, Title = "Canon EOS 525545", Brand = "Canon", Description = "Canon camera with advanced features, perfect for photography enthusiasts. Capture stunning images with ease.", Price = 80000, CategoryId = 3, ImageUrl = @"\images\product\97a286c0-b68f-4abd-8312-dd0ff65a7a86.jpg" },
    new Product { Id = 9, Title = "Canon PowerShot s333", Brand = "Canon", Description = "High-end Canon camera designed for professional photographers. Delivers exceptional image quality and performance.", Price = 400000, CategoryId = 3, ImageUrl = @"\images\product\349dfcc7-783e-495d-9521-fdbfe3c9cadc.jpg" },
    new Product { Id = 10, Title = "Suprima Secure n33", Brand = "Suprima", Description = "Suprima CCTV system for enhanced security. Reliable and easy to install, suitable for home and business surveillance.", Price = 25000, CategoryId = 2, ImageUrl = @"\images\product\b545a9c6-3192-4e0f-a6cb-1fa2ac95925a.webp" },
    new Product { Id = 11, Title = "Suprima Vision k33", Brand = "Suprima", Description = "Compact and efficient Suprima CCTV system for monitoring and security. Provides clear video footage for peace of mind.", Price = 23000, CategoryId = 2, ImageUrl = @"\images\product\4709384e-6e4b-441a-9735-8d3a52bcfadf.webp" },
    new Product { Id = 12, Title = "VivoTech Guardian 3sT", Brand = "Vivo tech", Description = "Vivo 3sT CCTV camera, designed for effective surveillance. Easy to install and operate, ideal for home security.", Price = 20000, CategoryId = 2, ImageUrl = @"" }
);


        }
    }
}
