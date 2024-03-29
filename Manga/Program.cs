using Manga.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PaginaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddScoped<CascadingAuthenticationState>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Usuarios/Login";
    options.LogoutPath = "/Home/Index";
    //options.DefaultScheme = "Bearer";
    //options.DefaultAuthenticateScheme = "Bearer";
    //options.DefaultChallengeScheme = "Bearer";
});
//}).AddJwtBearer(options =>
//{
//    options.Authority = builder.Configuration.GetValue<string>("Authority");
//    options.Audience = builder.Configuration.GetValue<string>("Audience");
//});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
