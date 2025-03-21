using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Cửu_hàng_thiết_bị_điện_tử.Data;
using Cửu_hàng_thiết_bị_điện_tử.Models;

namespace Cửu_hàng_thiết_bị_điện_tử.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Cửu_hàng_thiết_bị_điện_tửContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Cửu_hàng_thiết_bị_điện_tửContext>>()))
            {
                // Kiểm tra xem dữ liệu đã có chưa
                if (context.ĐT.Any())
                {
                    return; // Dữ liệu đã tồn tại, không cần thêm nữa
                }

                // Thêm dữ liệu mẫu
                context.ĐT.AddRange(
                    new ĐT
                    {
                        ProductName = "iPhone 15 Pro Max",
                        ManufactureDate = DateTime.Parse("2023-09-22"),
                        Category = "Smartphone",
                        Brand = "Apple",
                        Price = 1299.99M,
                        Stock = 50,
                        Description = "Điện thoại cao cấp với camera 48MP và chip A17 Pro.",
                        ImageUrl = "/img/png1.png"
                    },
                    new ĐT
                    {
                        ProductName = "Samsung Galaxy S24 Ultra",
                        ManufactureDate = DateTime.Parse("2024-01-17"),
                        Category = "Smartphone",
                        Brand = "Samsung",
                        Price = 1199.99M,
                        Stock = 40,
                        Description = "Màn hình 120Hz, bút S Pen, và camera 200MP.",
                        ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s25-ultra_3__3.png"
                    },
                    new ĐT
                    {
                        ProductName = "Sony WH-1000XM5",
                        ManufactureDate = DateTime.Parse("2022-05-12"),
                        Category = "Tai nghe",
                        Brand = "Sony",
                        Price = 399.99M,
                        Stock = 30,
                        Description = "Tai nghe chống ồn chủ động hàng đầu, pin lên tới 30 giờ.",
                        ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/a/tai-nghe-chup-tai-sony-wh-ch520-trang.png"
                    },
                    new ĐT
                    {
                        ProductName = "MacBook Pro M3",
                        ManufactureDate = DateTime.Parse("2024-02-01"),
                        Category = "Laptop",
                        Brand = "Apple",
                        Price = 2399.99M,
                        Stock = 20,
                        Description = "Laptop mạnh mẽ với chip M3 mới nhất, màn hình Retina.",
                        ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:358:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/m/image_1396_1.png"
                    }
                );

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();
            }
        }
    }
}
