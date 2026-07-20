using Microsoft.EntityFrameworkCore;
using CromosApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuramos SQLite para que guarde los datos en un archivo local llamado "cromos.db"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=cromos.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Este bloque crea el archivo físico de la base de datos automáticamente si no existe
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();