using AgendaApi.Data;
using AgendaApi.Repositories;
using AgendaApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DBContext - Base de Dados MySQL
var connectionString = builder.Configuration.GetConnectionString("AgendaConnection");

builder.Services
    .AddDbContext<AgendaContext>(opts => 
    opts.UseLazyLoadingProxies()    
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
    )
);

// Configuração do AutoMapper
builder.Services.
    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuração dos repositories e services
builder.Services.AddScoped<AgendaRepository>();
builder.Services.AddScoped<AgendaService>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<EnderecoService>();

// Configuração do CORS
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permitir qualquer origem
              .AllowAnyMethod()  // Permitir qualquer método HTTP
              .AllowAnyHeader(); // Permitir qualquer cabeçalho
    });
});

// Adiciona serviços ao container
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

// Ativa o CORS com a política "AllowAll"
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

// Configura o pipeline de requisições
app.MapControllers();

app.Run();
