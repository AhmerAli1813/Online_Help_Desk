
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
builder.Services.AddTransient<IAurtrizationServices, AurtrizationServices>();
builder.Services.AddDbContext<OHDDbContext>(option =>

        option.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"),
            b => b.MigrationsAssembly("DataAccessLayer"))
    );
//Session 
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//Session app
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Home}/{controller=Aurth}/{action=Index}/{id?}");

app.Run();
