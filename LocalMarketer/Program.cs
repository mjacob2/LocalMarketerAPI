using LocalMarketer.ApplicationServices.API.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LocalMarketer
{
        public class Program
        {
                public static void Main(string[] args)
                {
                        var builder = WebApplication.CreateBuilder(args);


                        builder.Services.AddControllers();
                        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                        builder.Services.AddEndpointsApiExplorer();
                        builder.Services.AddSwaggerGen();
                        // Lets enter the controller on request validation
                        builder.Services.Configure<ApiBehaviorOptions>(options => {
                                options.SuppressModelStateInvalidFilter = true;
                        });
                        builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
                        builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
                        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));
                        builder.Services.AddDbContext<LocalMarketerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalMarketerConnection")));
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
                }
        }
}