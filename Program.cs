using apidotnet.Context;
using apidotnet.Entity;
using apidotnet.Interface;
using apidotnet.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext"))
);

builder.Services.AddScoped(typeof(LivroInterface<>),typeof(LivroRepository<>));
builder.Services.AddAutoMapper(typeof(DataContext));
builder.Services.AddScoped<LivroRepository<Livro>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();