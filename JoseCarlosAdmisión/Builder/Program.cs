using AutoMapper;
using JoseCarlos.Application.Interfaz;
using JoseCarlos.Application.UseCases.Usuarios.CambiarPasswordUsuario;
using JoseCarlos.Application.UseCases.Usuarios.CrearUsuario;
using JoseCarlos.Application.UseCases.Usuarios.DarBajaAltaUsuario;
using JoseCarlos.Application.UseCases.Usuarios.Editar_Usuario;
using JoseCarlos.Application.UseCases.Usuarios.EliminarUsuario;
using JoseCarlos.Application.UseCases.Usuarios.GetActivos;
using JoseCarlos.Application.UseCases.Usuarios.GetTodos;
using JoseCarlos.Application.UseCases.Usuarios.LoginUsuario;
using JoseCarlos.Application.UseCases.Usuarios.ResetearUsuario;
using JoseCarlos.Domain.Correo;
using JoseCarlos.Domain.IRepositories;
using JoseCarlos.Infraestructure.Correo;
using JoseCarlos.Infraestructure.Gestion;
using JoseCarlos.Infraestructure.Repositories;
using JoseCarlosAdmisión.Middlewares;
using JoseCarlosAdmisión.Seguridad;
using JoseCarlosAdmisión.UsesCases.Usuarios.CrearUsuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
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
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<EliminarUsuarioUseCase>();
builder.Services.AddScoped<GetTodosUsuarioUseCase>();
builder.Services.AddScoped<EditarUsuarioUseCase>();
builder.Services.AddScoped<DarBajaAltaUsuarioUseCase>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<CambiarPasswordUsuarioUseCase>();
builder.Services.AddScoped<LoginUsuarioUseCase>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUsuarioApi, UsuarioApi>();
builder.Services.AddScoped<GetActivosUsuarioUseCase>();
//builder.Services.AddScoped<IGestionCorreo, GestionCorreo>();
builder.Services.AddScoped<ResetearUsuarioUseCase>();

//Configuración del Correo
builder.Services.Configure<IConfigCorreo>(builder.Configuration.GetSection("ConfigCorreo"));
builder.Services.AddScoped<IConfigCorreo, ConfigCorreo>();
builder.Services.AddScoped<IGestionCorreo, GestionCorreo>(serviceProvider =>
{
    // Obtén los valores de la configuración
    var config = builder.Configuration.GetSection("ConfigCorreo").Get<ConfigCorreo>();
    // Crea la instancia de ConfigCorreo con los parámetros requeridos
    return new GestionCorreo(config);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
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