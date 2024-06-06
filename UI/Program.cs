
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OHD.DataAccessLayer;
using OHD.Infrastructure;
using OHD.Services;
using OHD.Services.utilityClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRegisterServices, RegisterServices>();
builder.Services.AddScoped<IAurtrizationServices, AurtrizationServices>();
//builder.Services.AddScoped<IRolesServices, RolesServices>();
builder.Services.AddScoped<IFacilityServices, FacilityServices>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
//builder.Services.AddDbContext<OHDDbContext>(option =>

//        option.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"),
//            b => b.MigrationsAssembly("DataAccessLayer"))
//    );
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OHDDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
	Option =>
	{
		Option.Password.RequiredUniqueChars = 0;
		Option.Password.RequiredLength = 8;
		Option.Password.RequireNonAlphanumeric = false;
		Option.Password.RequireLowercase = false;

	}).AddEntityFrameworkStores<OHDDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
	// Password settings.
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 1;

	// Lockout settings.
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.AllowedForNewUsers = true;

	// User settings.
	options.User.AllowedUserNameCharacters =
	"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	options.User.RequireUniqueEmail = false;
});



builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
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
	pattern: "{area=Home}/{controller=Account}/{action=Login}/{id?}");
//app.MapRazorPages();
app.Run();
