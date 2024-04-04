using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework;
using FluentValidation.AspNetCore;
using PowerBITurkeyBlog.Business.ValidationRules.FluentValidation;
using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Business.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PostSharp.Extensibility;
using PowerBITurkeyBlog.Business.Mapping.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AccountValidator>());



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PowerBiTurkeyContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IAccountDal, EfAccountDal>();
builder.Services.AddScoped<IAccountService, AccountManager>();


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
