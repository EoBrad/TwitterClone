using Microsoft.EntityFrameworkCore;
using TwitterClone.Context;
using FluentValidation.AspNetCore;
using FluentValidation;
using TwitterClone.Services.Configuration;
using TwitterClone.Mapper;
using TwitterClone.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Auto Validations
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(DtoToModel));

// Add Services
builder.Services.AddRepositories();
builder.Services.AddUseCases();
builder.Services.AddAwsClient(builder.Configuration);

// Add Exeption Filter
builder.Services.AddMvc(options => options.Filters.Add<ExeptionFilter>());

// Add Jwt Authentication
builder.Services.AddJwtSecurity();

var conString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conString, ServerVersion.AutoDetect(conString)));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();