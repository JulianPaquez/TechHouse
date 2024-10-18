using Appication.Interfaces;
using Application;

using Application.Service;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Application.Services;

using Application.Interfaces;

using Microsoft.OpenApi.Models;
using System.Reflection;
using static Infrastructure.Services.AuthService;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Application.Interfaces;
using Infrastructure.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
setupAction.AddSecurityDefinition("PIII-TPIBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
{
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    Description = "Aca pegar el token generado al loguearse."
}););
setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "PIII-TPIBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //setupAction.IncludeXmlComments(xmlPath); no se pudo configurar el archivo xml

#region Services
builder.Services.AddScoped<ISysAdminService, SysAdminService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.Configure<AuthenticationServiceOptions>(
    builder.Configuration.GetSection(AuthenticationServiceOptions.AuthService)
);

#endregion

#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISysAdminRepository, SysAdminRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();


builder.Services.AddScoped<IBaseRepository<User>, EfRepository<User>>();


builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AuthService:Issuer"], // Aquí está buscando en "AuthService"
            ValidAudience = builder.Configuration["AuthService:Audience"], // Aquí está buscando en "AuthService"
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthService:SecretForKey"])) // Aquí está buscando en "AuthService"
        };
    });



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
