using System.ComponentModel.DataAnnotations;

namespace Cửu_hàng_thiết_bị_điện_tử.Models
{
    public class ĐT
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }

        public string? Category { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; internal set; }
    }
}

