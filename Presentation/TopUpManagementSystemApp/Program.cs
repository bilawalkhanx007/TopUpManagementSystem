using Application;
using DataAcessPersistence;
using DataAcessPersistence.UnitOfWork;
using Domain.Abstructions;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Domain.Exceptions;
using DataAcessPersistence.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


#region Api Versioning
//  API Versioning
builder.Services.AddApiVersioning(config =>
{
    // API Version as 1.0
    config.DefaultApiVersion = new ApiVersion(1, 0);
    // If the client hasn't specified the API version in the request, use the default API version number 
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
});
#endregion

builder.Services.AddEndpointsApiExplorer();

//Register Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//Registere Application and DataAcess Dependies.
builder.Services.AddApplication()
                .AddPersistence(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Globallly Handling Exceptions
app.UseExceptionHandlerMiddleware();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
