using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using PowerBITurkeyBlog.Business.ValidationRules.FluentValidation;
using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Business.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PostSharp.Extensibility;
using PowerBITurkeyBlog.Business.Mapping.AutoMapper;
using PowerBITurkeyBlog.WebAPI.Filter;
using Microsoft.AspNetCore.Mvc;
using PowerBITurkeyBlog.Core.Abstract;
using PowerBITurkeyBlog.Core.Concrete.EntityFramework;
using FluentValidation;
using System;
using PowerBITurkeyBlog.Entities.Entities;
using PowerBITurkeyBlog.Entities.OtherEntities;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilter()))
	.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AccountValidator>());


builder.Services.Configure<ApiBehaviorOptions>(optinons => { optinons.SuppressModelStateInvalidFilter = true; });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PowerBiTurkeyContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IAccountDal, EfAccountDal>();
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IValidator<AccountDto>, AccountValidator>();

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
