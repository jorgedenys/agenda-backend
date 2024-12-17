using AgendaApi.Data;
using AgendaApi.Repositories;
using AgendaApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DBContext - Base de Dados MySQL
var connectionString = builder.Configuration.GetConnectionString("AgendaConnection");

builder.Services
    .AddDbContext<AgendaContext>(opts => 
    opts.UseLazyLoadingProxies()    
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
    )
);

// Configura��o do AutoMapper
builder.Services.
    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configura��o dos repositories e services
builder.Services.AddScoped<AgendaRepository>();
builder.Services.AddScoped<AgendaService>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<EnderecoService>();

// Configura��o do CORS
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permitir qualquer origem
              .AllowAnyMethod()  // Permitir qualquer m�todo HTTP
              .AllowAnyHeader(); // Permitir qualquer cabe�alho
    });
});

// Adiciona servi�os ao container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ativa o CORS com a pol�tica "AllowAll"
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

// Configura o pipeline de requisi��es
app.MapControllers();

app.Run();
