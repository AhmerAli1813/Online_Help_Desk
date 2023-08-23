
using OHD.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using OHD.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using OHD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRegisterServices, RegisterServices>();
builder.Services.AddScoped<IAurtrizationServices, AurtrizationServices>();
builder.Services.AddScoped<IRolesServices, RolesServices>();
builder.Services.AddScoped<IFacilityServices, FacilityServices>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
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
    pattern: "{area=Home}/{controller=Auth}/{action=Index}/{id?}");

app.Run();
