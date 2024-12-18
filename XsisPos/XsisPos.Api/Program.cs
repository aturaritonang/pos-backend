using Microsoft.EntityFrameworkCore;
using XsisPos.Api.Repositories;
using XsisPos.Dto;
using XsisPos.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<XsisPosDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("XsisPosConnection")));
builder.Services.AddDbContext<XsisPosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("XsisPosConnection")));

builder.Services.AddScoped<ICategoryRepository<CategoryDto, ChangeCategoryDto>, CategoryRepository>();
builder.Services.AddScoped<IProductRepository<ProductDto, ChangeProductDto>, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();
