using Employee.DAL.FluentValidators;
using Employee.DAL.Handlers;
using Employee.DAL.Services;
using FluentValidation;
using MediatR;
using Employee.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(EmployeeLibrary).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<AddEmployeeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateEmployeeValidator>();
builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<ILoggerService, FileLoggerService>();

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
