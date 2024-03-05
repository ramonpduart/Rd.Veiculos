using Microsoft.AspNetCore.ResponseCompression;
using Rd.Veiculos.Api.Infraestructure.SqlServer;
using System.IO.Compression;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
    //cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    //cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
});

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
