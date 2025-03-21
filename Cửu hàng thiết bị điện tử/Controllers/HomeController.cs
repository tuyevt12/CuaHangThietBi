using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cửu_hàng_thiết_bị_điện_tử.Models;

namespace Cửu_hàng_thiết_bị_điện_tử.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Details(int id)
    {
        // Lấy dữ liệu sản phẩm từ database hoặc danh sách giả lập
        var product = new Product
        {
            Id = id,
            TenSanPham = "iPhone 16 Pro Max",
            Gia = 31170000,
            MoTa = "Sản phẩm mới nhất từ Apple với thiết kế Titan tuyệt đẹp."
        };

        // Trả về view Details.cshtml và truyền product sang
        return View("Details", product);
    }
}

