using Microsoft.EntityFrameworkCore;
using PasswordManager.DataBases;
using PasswordManager.Models.Entities;
using PasswordManager.Repository;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Services;
using PasswordManager.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<IPasswordRecordService, PasswordRecordService>();
builder.Services.AddTransient<IPasswordRepository, PasswordRepository>();

builder.Services.AddDbContext<PasswordManagerDbContext>(options =>
{
    var connectionString = builder.Configuration.GetValue<string>("Sql");

    connectionString =
        connectionString!.Replace("${DB_SERVER}", Environment.GetEnvironmentVariables()["DB_SERVER"]!.ToString());
    connectionString =
        connectionString.Replace("${DB_NAME}", "PasswordDb");
    connectionString =
        connectionString.Replace("${DB_USER}", Environment.GetEnvironmentVariables()["DB_USER"]!.ToString());
    connectionString =
        connectionString.Replace("${DB_PASS}", Environment.GetEnvironmentVariables()["DB_PASS"]!.ToString());

    options.UseMySQL(connectionString);
}, ServiceLifetime.Transient);


var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();