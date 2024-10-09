using Appication.Interfaces;
using Application;

using Application.Service;
using Domain;
using Domain.Entities;
using Domain.Interfaces;

using Infrastructure.Repositories;

using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Microsoft.Data.Sqlite;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Services
builder.Services.AddScoped<ISysAdminService, SysAdminService>();
builder.Services.AddScoped<IAdminService, AdminService>();
#endregion

#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISysAdminRepository, SysAdminRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

#endregion

var connection = new SqliteConnection("Data source = DB-TechHouse.db");
connection.Open();

using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(connection, b => b.MigrationsAssembly("Infrastructure")));

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
