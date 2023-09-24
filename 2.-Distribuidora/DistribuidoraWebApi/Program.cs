using DistribuidoraDatos.Configracion;
using DistribuidoraDatos.Repositorio;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConfiguracionConexion>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ITipoProductoRepositorio, TipoProductoRepositorio>();
builder.Services.AddScoped<IProveedorRepositorio,ProveedorRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwagger(x => x.SerializeAsV2 = true);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
