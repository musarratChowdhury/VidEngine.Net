using System.Security.Cryptography.X509Certificates;
using VidEngine.Api.Services;
using VidEngine.Domain;
using VidEngine.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from config
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register infrastructure (DbContext, repositories, etc.)
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddScoped<VideoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        httpsOptions.ServerCertificate = new X509Certificate2("/https/devcert.pfx", "mushcorp123");
    });
});


var corsOrigins = builder.Configuration.GetSection("Cors:Origins").Get<string>();

Console.WriteLine(corsOrigins);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();