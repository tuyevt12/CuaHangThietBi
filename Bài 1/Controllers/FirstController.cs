using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Bài_1.Controllers
{
    public class FirstController : Controller
    {
        public string Index()
        {
            return "Toi la Controller dau tien.";
        }
        public string Welcome(string HovaTen, int Tuoi = 1)
        {
            return HtmlEncoder.Default.Encode($"Xin chao {HovaTen}, Co phai tuoi cua ban la: {Tuoi}");
        }
    }
}
