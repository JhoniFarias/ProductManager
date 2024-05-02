using Microsoft.EntityFrameworkCore;
using ProductContext.API.Automapper;
using ProductContext.API.Extensions;
using ProductContext.API.Filters;
using ProductContext.Application.UseCases.Product.Commands;
using ProductContext.Application.UseCases.Product.Commands.interfaces;
using ProductContext.Application.UseCases.Product.Queries;
using ProductContext.Application.UseCases.Product.Queries.interfaces;
using ProductContext.Domain.Repositories;
using ProductContext.Infrastructure;
using ProductContext.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(router => router.LowercaseUrls = true);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IRegisterProductUseCase, RegisterProductUseCase>();

builder.Services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
builder.Services.AddTransient<IDisableProductUseCase, DisableProductUseCase>();

builder.Services.AddTransient<IRequestProductByFilterUseCase, RequestProductByFilterUseCase>();
builder.Services.AddTransient<IRequestProductByIdUseCase, RequestProductByIdUseCase>();

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperConfig());
}).CreateMapper());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

await app.MigrateDb();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
