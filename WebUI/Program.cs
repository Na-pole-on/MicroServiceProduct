using WebUI;
using WebUI.Services;
using WebUI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IItemService, ItemService>();
SD.ItemMicroservice = builder.Configuration["ServiceUrls:ItemMicroservice"];

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
