global using System.ComponentModel.DataAnnotations;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using WebApplications.Models;
global using WebApplications.Services;
global using WebApplications.Data;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultSQLConnection");
builder.Services.AddDbContext<EmpContext>(x =>
{
    x.UseSqlServer(connectionString);
});



builder.Services.AddDbContext<EmpContext>(con => con.UseSqlServer(builder.Configuration.GetConnectionString("connection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));



builder.Services.AddScoped<IEmpService, EmpService>();

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
