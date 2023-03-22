using contact_app.Controllers;
using contact_app.Data;
using contact_app.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSqlServer<ContactAppContext>(builder.Configuration.GetConnectionString("ContactDb"));

builder.Services.AddScoped<IUserService,  UserService>();

//Configuracion de una cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(c =>
{
    c.LoginPath = "/Login/Index";
    c.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    c.AccessDeniedPath = "/Dashboard/index";
});

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

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
