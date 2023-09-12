using Microsoft.Extensions.Options;
using UserService.MongoDBSettings;
using UserService.Repository;
using UserService.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<InnovatorDBSettings>(
             builder.Configuration.GetSection(nameof(InnovatorDBSettings)));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<InnovatorDBSettings>>().Value);

builder.Services.AddSingleton<IInnovatorRepository,InnovatorRepository>();
builder.Services.AddSingleton<IInnovatorService, InnovatorService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
