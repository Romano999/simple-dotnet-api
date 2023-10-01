using SimpleDotnetApi.Adapter.Postgresql;
using SimpleDotnetApi.Core.Database;
using SimpleDotnetApi.Core.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
//builder.Services.AddScoped<IProductRepository, ProductRepository>(
//	provider => ActivatorUtilities.CreateInstance<ProductRepository>(provider, settings));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Dependency injection
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.MapControllers();

app.Run();

public partial class Program { }
