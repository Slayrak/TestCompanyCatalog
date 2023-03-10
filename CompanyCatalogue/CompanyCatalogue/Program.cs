using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using CompanyCatalogue.Repositories;
using CompanyCatalogue.Services;
using CompanyCatalogue.ServicesConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MigrateDatabase();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
