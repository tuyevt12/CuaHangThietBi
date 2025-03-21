using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cửu_hàng_thiết_bị_điện_tử.Models
{
    public class DeviceCategoryViewModel
    {
        public List<ĐT>? Devices { get; set; }
        public SelectList? Categories { get; set; }
        public string? SelectedCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
