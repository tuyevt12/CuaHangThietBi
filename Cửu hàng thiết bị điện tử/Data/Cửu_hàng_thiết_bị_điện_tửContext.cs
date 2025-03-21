using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cửu_hàng_thiết_bị_điện_tử.Models;

namespace Cửu_hàng_thiết_bị_điện_tử.Data
{
    public class Cửu_hàng_thiết_bị_điện_tửContext : DbContext
    {
        public Cửu_hàng_thiết_bị_điện_tửContext (DbContextOptions<Cửu_hàng_thiết_bị_điện_tửContext> options)
            : base(options)
        {
        }

        public DbSet<Cửu_hàng_thiết_bị_điện_tử.Models.ĐT> ĐT { get; set; } = default!;
    }
}
