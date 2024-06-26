using Job_candidate_hub_API.Data;
using Job_candidate_hub_API.Repositories.IRepos;
using Job_candidate_hub_API.Repositories.Repos;
using Job_candidate_hub_API.Services.IService;
using Job_candidate_hub_API.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Services & Repos Registration
    builder.Services.AddScoped<ICandidateRepo, CandidateRepo>();
    builder.Services.AddScoped<ICandidateService, CandidateService>();
#endregion

#region CORS
    builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyAllowSpecificOrigins", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });
#endregion

#region Connection To SQL Server
    builder.Services.AddDbContext<CandidateHubDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
