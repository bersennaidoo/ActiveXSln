using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ActiveX.Infrastructure.PGSQLDbContext;
using ActiveX.Models;
using ActiveX.Services;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<PGSQLDbContext>(options => {
        options.UseNpgsql(
                builder.Configuration["ConnectionStrings:PGSQLDbContext"]);
        });

builder.Services.AddScoped<IActiveXService, EFActiveXService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
