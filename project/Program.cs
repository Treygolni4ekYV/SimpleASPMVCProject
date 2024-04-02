using Microsoft.EntityFrameworkCore;
using project.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(
    opt => opt.UseSqlite("Data Source=ProjectData.db ")
);

var app = builder.Build();
app.UseStaticFiles();//подключаем папку wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}"
);

app.Run();
