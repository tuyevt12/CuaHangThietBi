using Cửu_hàng_thiết_bị_điện_tử.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cửu_hàng_thiết_bị_điện_tử.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Cửu_hàng_thiết_bị_điện_tửContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cửu_hàng_thiết_bị_điện_tửContext") ?? throw new InvalidOperationException("Connection string 'Cửu_hàng_thiết_bị_điện_tửContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();