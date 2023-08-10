
using OHD.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using OHD.DataAccessLayer.Infrastructure.IRepository;
using OHD.DataAccessLayer.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using OHD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRegisterServices, RegisterServices>();
builder.Services.AddDbContext<OHDDbContext>(option =>

        option.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"),
            b => b.MigrationsAssembly("DataAccessLayer"))
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Roles}/{action=Index}/{id?}");

app.Run();
