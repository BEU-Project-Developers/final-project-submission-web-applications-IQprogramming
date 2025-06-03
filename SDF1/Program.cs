using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SDF1.Data;
using SDF1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<KellyContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("KellyContext"))
);

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        // You can tweak Password settings, lockout settings, etc. here if desired
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<KellyContext>()   // ← this hooks up EF Core stores
    .AddDefaultTokenProviders();    

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
