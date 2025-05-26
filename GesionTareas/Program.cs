using Aplicacion.Servicios;
using Dominio.Interfaces;
using Infraestructura;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ServicioTareaDominio>();
builder.Services.AddScoped<IRepositorioTareas, RepositorioTareas>();
builder.Services.AddScoped<IServicioTarea, ServicioTarea>();
builder.Services.AddDbContext<ContextTareas>(options 
       => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionTareas")));


builder.Services.AddControllers();

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
