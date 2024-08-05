using API.Controllers;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<BoardRepository>();
builder.Services.AddScoped<BoardService>();
builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<SectionRepository>();
builder.Services.AddScoped<SectionService>();

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
