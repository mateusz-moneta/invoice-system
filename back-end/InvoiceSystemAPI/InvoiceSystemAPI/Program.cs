using InvoiceSystemAPI.Configuration;
using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Seeds.Abstracts;
using InvoiceSystemAPI.Seeds;
using InvoiceSystemAPI.Services;
using InvoiceSystemAPI.Services.Abstracts;
using InvoiceSystemAPI.Tools;
using InvoiceSystemAPI.Tools.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Tools
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

// Configuration
AuthenticationConfiguration authenticationConfiguration = new();
builder.Configuration.GetSection(nameof(AuthenticationConfiguration)).Bind(authenticationConfiguration);
builder.Services.AddSingleton(authenticationConfiguration);

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Data Generators
builder.Services.AddScoped<UserDataGenerator>();

builder.Services.AddControllers();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationConfiguration.JwtIssuer,
        ValidAudience = authenticationConfiguration.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfiguration.JwtKey))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("myAppCors");

app.MapControllers();

using (IServiceScope scope = app.Services.CreateScope())
{
    DataContext dbContext = scope.ServiceProvider.GetService<DataContext>();
    if (!dbContext.Database.CanConnect())
    {
        throw new Exception("Connection string is incorrect or database not exists!");
    }

    IDataGenerator userDataGenerator = scope.ServiceProvider.GetService<UserDataGenerator>();
    await userDataGenerator.SeedAsync();
}

app.Run();
