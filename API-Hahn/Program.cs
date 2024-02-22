using API.Domain.Entities;
using API.Domain.Interfaces;
using API.Infra.Data.Context;
using API.Infra.Data.Repository;
using API.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc(
        "v1",
        new OpenApiInfo
        { Title = "API - Hahn Solution", Version = "v1" });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<MySqlContext>();

builder.Services.AddSingleton(new MapperConfiguration(config =>
{
/*    config.CreateMap<CreateUserModel, User>();
    config.CreateMap<UpdateUserModel, User>();
    config.CreateMap<User, UserModel>();*/
}).CreateMapper());


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
