using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ActiveX.Data.Repository;
using ActiveX.Models.Contracts;
using ActiveX.Models.Data;
using ActiveX.Services;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<PGDbContext>(options => {
        options.UseNpgsql(
                builder.Configuration["ConnectionStrings:PGDbContext"]);
        });

builder.Services.AddScoped<IProductService, EFProductService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
