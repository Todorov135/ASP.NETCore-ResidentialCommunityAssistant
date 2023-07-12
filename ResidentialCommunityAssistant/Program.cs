using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResidentialCommunityAssistant.Data;
using ResidentialCommunityAssistant.Data.Models;
using ResidentialCommunityAssistant.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
var configuration = configBuilder.Build();
var passwordConfigDevEnv = configuration.GetSection("PasswordManagement");

builder.Services.AddDbContext<CommunityAssistantDBContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<ExtendedUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = passwordConfigDevEnv.GetValue<bool>("RequireConfirmedAccount");
    options.Password.RequireDigit = passwordConfigDevEnv.GetValue<bool>("RequireDigit");
    options.Password.RequireNonAlphanumeric = passwordConfigDevEnv.GetValue<bool>("RequireNonAlphanumeric");
    options.Password.RequireUppercase = passwordConfigDevEnv.GetValue<bool>("RequireUppercase");
})    
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CommunityAssistantDBContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.IsEssential = true;
});
builder.Services.AddApplicationService();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "ShopAdministrator",
    pattern: "{area:exists}/{controller=ShopÌanagement}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
