using IUCULTURE.Back.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).AddCookie(
    JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Account/Login";
        opt.LogoutPath = "/Account/Logout";
        opt.AccessDeniedPath = "/Account/AccessDenied";
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "IUCULTURECookie";

    });   




var app = builder.Build();

app.UseStaticFiles();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").AllowAnonymous();
else
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
