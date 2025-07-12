using AutoMapper;
using BulletinBoard.Application.Common.Interfaces;
using BulletinBoard.Application.Features.Bulletin;
using BulletinBoard.Application.Mappers;
using BulletinBoard.Infrastructure.Helpers;
using BulletinBoard.Infrastructure.Persistence;
using BulletinBoard.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

namespace BulletinBoard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog(logger);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BulletinBoard.API", Version = "v1" }));
         
            builder.Services.AddAutoMapper(typeof(AnnouncementMappingProfile).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllQuery).Assembly));
            builder.Services.AddScoped<IBulletin, BulletinService>();
            builder.Services.AddScoped<UpdateHelper>();

            // Add services to the container.
            builder.Services.AddOpenApi();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DatabaseConnection"),
                    new MySqlServerVersion(new Version(8, 0, 41))));

            builder.Services.AddCors(o => o.AddPolicy("AllowAny", corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowAny");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
