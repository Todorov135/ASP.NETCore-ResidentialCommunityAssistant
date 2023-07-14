using Microsoft.EntityFrameworkCore;
using ResidentialCommunityAssistant.Data;
using ResidentialCommunityAssistant.Services.Contracts.HomeManager;
using ResidentialCommunityAssistant.Services.Services.HomeManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CommunityAssistantDBContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddTransient<IHomeManagerService, HomeManagerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
