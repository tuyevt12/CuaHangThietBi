using Microsoft.AspNetCore.Mvc;

namespace Bài_2.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}