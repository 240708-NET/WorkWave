using API.Controllers;
using Microsoft.EntityFrameworkCore;
using Repository;
using DotNetEnv;
using Services;


var builder = WebApplication.CreateBuilder(args);

Env.Load("../Services/connectionstring.env");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

if(string.IsNullOrEmpty(connectionString)){
    throw new InvalidOperationException("Connection string not found.");
}

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

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

builder.Services.AddCors();

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

app.UseCors(options =>
    options.AllowAnyHeader()
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowCredentials()
);

app.Run();
