using ChatService.Models;
using ChatService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ChatDbContext>(
   builder.Configuration.GetSection("ChatContextValues"));

builder.Services.AddScoped<IChatRepo, ChatRepo>();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null).AddNewtonsoftJson();
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
