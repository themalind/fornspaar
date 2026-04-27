using Fornspar.Core;
using Fornspar.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFornsparData(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Run database migrations at startup
foreach (var migrationRunner in app.Services.GetServices<IDbMigrationRunner>())
{
    await migrationRunner.RunMigrationsAsync(app.Lifetime.ApplicationStopping);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
