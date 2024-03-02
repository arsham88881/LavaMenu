using LavaMenu.Application;
using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.infrastructure.DBcontext;
using LavaMenu.WebEndpoint.Controllers.MinimalApi;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
var configure = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

// Add services to the IOC container.
builder.Services.AddControllersWithViews();
///////////////////////////////////////delevope log configure
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

/////////////////////////////////////////////////configure dataBase
builder.Services.Add(new ServiceDescriptor(typeof(Idb), typeof(db), ServiceLifetime.Scoped));
builder.Services.AddDbContext<db>(option => option.UseSqlServer(configure["ConStringToSqlServer"]));
/////////////////////////////////////////////////

builder.Services.AddApplicationServices(); //custom 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.UseCateguryMinimalApi();

app.Run();
