using Microsoft.EntityFrameworkCore;
using PatientApi.Data;

/*
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef database remove
*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PatientContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("PatientContext")));

// Add Swagger
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