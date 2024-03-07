using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using Rd.Veiculos.Api.Infraestructure.SqlServer;
using Rd.Veiculos.Api.Middlewares;
using System.IO.Compression;
using System.Reflection;

const string BASEPATH = "rd-veiculos-api";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = BASEPATH, Description = "Projeto para gerenciar veículos.", Version = "v1" });
});
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});
builder.Services.AddSqlServer();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UsePathBase("/" + BASEPATH);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/{BASEPATH}/swagger/v1/swagger.json", $"{BASEPATH} v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
