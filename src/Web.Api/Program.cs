using DotNetEnv;
using Infrastructure.Data;
using Infrastructure.Data.Configuration;

var rootPath = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;
Env.Load(Path.Combine(rootPath, ".env"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppServices(builder.Configuration);

builder.Services.AddScoped<ApplicationDbContextInitialiser>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));

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

using (var scope = app.Services.CreateScope())
{
    var dbContextInitializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await dbContextInitializer.InitialiseAsync();
}

app.Run();