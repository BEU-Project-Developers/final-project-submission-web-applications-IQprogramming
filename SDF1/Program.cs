using Microsoft.EntityFrameworkCore;
using SDF1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<KellyContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("KellyContext"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
