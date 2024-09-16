using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EmployeeDbContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString("EmployeeContext")));


builder.Services.AddDbContext<ProjectDbContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString("ProjectContext")));



builder.Services.AddDbContext<Employee_ProjectDbContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString("Employee_ProjectContext")));


builder.Services.AddDbContext<EffortDbContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString("EffortContext")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.MapControllers();

app.Run();
