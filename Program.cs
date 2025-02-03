using Microsoft.EntityFrameworkCore;
using TdoTareasBackend.Data;
using TdoTareasBackend.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
     options.AddPolicy("AllowAll", builder =>
    {
        builder
            .WithOrigins(
                "http://localhost:4200",     
                "http://localhost:7200",    
                "http://localhost:52482"     
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// 2. Servicios base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 3. Servicios propios
builder.Services.AddScoped<ITareasService, TareaService>();

// 4. Configuración Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tareas API",
        Version = "v1",
        Description = "API para gestión de tareas"
    });
});

// 5. Configuración DB Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 6. Construir la aplicación
var app = builder.Build();

// 7. Pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 8. Middleware en orden correcto
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Usa la misma política definida arriba
app.UseAuthorization();
app.MapControllers();

app.Run();