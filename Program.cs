using DynamicPricing.Data;
using DynamicPricing.Profiles;
using DynamicPricing.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<RetailerService>();
builder.Services.AddScoped<DynamicPricingContext>();

// For Usage of SQLLite
builder.Services.AddSqlite<DynamicPricingContext>("Data Source=DynamicPricing.db");

// For usage of AutoMapper to map to models to DTO and vice versa
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
