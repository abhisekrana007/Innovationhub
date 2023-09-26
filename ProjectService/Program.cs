using ProjectService.Models;
using ProjectService.Repository;
using ProjectService.services;
using ProjectService.Services;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("projectDB")
    );
builder.Services.AddScoped<IProjectServices, ProjectServicess>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();

builder.Services.AddScoped<IProposalRepo, ProposalRepo>();
builder.Services.AddScoped<IProposalService, ProposalService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


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
