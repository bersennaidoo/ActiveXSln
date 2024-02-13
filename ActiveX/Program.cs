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
app.MapControllerRoute("catpage",
        "{category}/Page{productPage:int}",
        new 
        { 
           Controller = "Home",
           action = "Index"
        }
     );

app.MapControllerRoute("page",
        "Page{productPage:int}",
        new 
        { 
           Controller = "Home",
           action = "Index",
           productPage = 1
        }
     );

app.MapControllerRoute("category",
        "{category}",
        new 
        { 
           Controller = "Home",
           action = "Index",
           productPage = 1
        }
     );

app.MapControllerRoute("pagination",
        "Products/Page{productPage}",
        new 
        { 
           Controller = "Home",
           action = "Index",
           productPage = 1
        }
     );




app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
