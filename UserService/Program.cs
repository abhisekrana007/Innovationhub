using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserService.MongoDBSettings;
using UserService.Repository;
using UserService.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<InnovatorDatabaseSettings>(
             builder.Configuration.GetSection(nameof(InnovatorDatabaseSettings)));

builder.Services.AddSingleton<IInnovatorDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<InnovatorDatabaseSettings>>().Value);


builder.Services.Configure<ExpertDatabaseSettings>(
             builder.Configuration.GetSection(nameof(ExpertDatabaseSettings)));

builder.Services.AddSingleton<IExpertDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ExpertDatabaseSettings>>().Value);

builder.Services.AddSingleton<IInnovatorRepository,InnovatorRepository>();
builder.Services.AddSingleton<IInnovatorService, InnovatorService>();


builder.Services.AddSingleton<IExpertRepository, ExpertRepository>();
builder.Services.AddSingleton<IExpertService, ExpertService>();
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateAudience = true,
                                ValidateIssuer = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                ValidAudience = builder.Configuration["Jwt:Audience"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                            };
                        });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
