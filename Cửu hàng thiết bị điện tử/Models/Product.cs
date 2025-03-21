using Microsoft.AspNetCore.Mvc;

namespace Cửu_hàng_thiết_bị_điện_tử.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public string MoTa { get; set; }
    }

}
