using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResidentialCommunityAssistant.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

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

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = passwordConfigDevEnv.GetValue<bool>("RequireConfirmedAccount");
    options.Password.RequireDigit = passwordConfigDevEnv.GetValue<bool>("passwordConfigDevEnv");
    options.Password.RequiredLength = passwordConfigDevEnv.GetValue<int>("RequiredLength");
    options.Password.RequireNonAlphanumeric = passwordConfigDevEnv.GetValue<bool>("RequireNonAlphanumeric");
    options.Password.RequireUppercase = passwordConfigDevEnv.GetValue<bool>("RequireUppercase");
})
    .AddEntityFrameworkStores<CommunityAssistantDBContext>();
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
