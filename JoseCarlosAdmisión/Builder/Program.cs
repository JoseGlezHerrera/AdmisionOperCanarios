using AutoMapper;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Application.UseCases.Usuarios.CambiarPasswordUsuario;
using JoseCarlos.Application.UseCases.Usuarios.CrearUsuario;
using JoseCarlos.Application.UseCases.Usuarios.DarBajaAltaUsuario;
using JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario;
using JoseCarlos.Application.UseCases.Usuarios.EliminarUsuario;
using JoseCarlos.Application.UseCases.Usuarios.GetTodos;
using JoseCarlos.Application.UseCases.Usuarios.LoginUsuario;
using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Infraestructure.Gestion;
using JoseCarlos.Infraestructure.Repositories;
using JoseCarlosAdmisión.Seguridad;
using JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddAutoMapper(typeof(EditarUsuarioMapping).Assembly);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

//Configuración de la cadena de conexión desde el json appsettings.
builder.Services.AddDbContext<GestionContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(5, 7, 11))));

// Configuración de autenticación
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"])
            )
        };
    });

//Servicios
builder.Services.AddScoped<CrearUsuarioUseCase>();
builder.Services.AddScoped<IGestionUOW, GestionUOW>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<EliminarUsuarioUseCase>();
builder.Services.AddScoped<GetTodosUsuarioUseCase>();
builder.Services.AddScoped<EditarUsuarioUseCase>();
builder.Services.AddScoped<DarBajaAltaUsuarioUseCase>();
builder.Services.AddScoped<CambiarPasswordUsuarioUseCase>();
builder.Services.AddScoped<LoginUsuarioUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();


