using LocalMarketer.ApplicationServices.API.Domain.Responses;
using LocalMarketer.DataAccess.CQRS;
using LocalMarketer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LocalMarketer.Authentication;
using Microsoft.AspNetCore.Authentication;
using FluentValidation.AspNetCore;
using FluentValidation;
using LocalMarketer.ApplicationServices.API.Validators;
using LocalMarketer.ApplicationServices;

namespace LocalMarketer
{
        public class Program
        {
                public static void Main(string[] args)
                {
                        var builder = WebApplication.CreateBuilder(args);

                        string environmentName = builder.Environment.EnvironmentName;

                        builder.Services.AddCors((options =>
                        {
                                options.AddDefaultPolicy(
                                    builder =>
                                    {
                                            builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                                    });
                        }));
                        builder.Services.AddAuthentication("BasicAuthentication")
                                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
                        builder.Services.AddFluentValidationAutoValidation();
                        builder.Services.AddFluentValidationClientsideAdapters();
                        builder.Services.AddValidatorsFromAssemblyContaining<AddClientRequestValidator>();
                        ValidatorOptions.Global.LanguageManager.Enabled = false;

                        // Lets enter the controller on request validation
                        builder.Services.Configure<ApiBehaviorOptions>(options =>
                        {
                                options.SuppressModelStateInvalidFilter = true;
                        });
                        builder.Services.AddControllers();
                        builder.Services.AddEndpointsApiExplorer();
                        builder.Services.AddSwaggerGen();
                        // Lets enter the controller on request validation
                        builder.Services.Configure<ApiBehaviorOptions>(options =>
                        {
                                options.SuppressModelStateInvalidFilter = true;
                        });
                        builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
                        builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
                        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ResponseBase<>)));
                        builder.Services.AddDbContext<LocalMarketerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalMarketerConnection")));

                        builder.Services.AddTransient<IImageDecoder, ImageDecoder>();

                        var app = builder.Build();

                        if (app.Environment.IsDevelopment())
                        {
                                app.UseSwagger();
                                app.UseSwaggerUI();
                        }
                        app.UseStaticFiles();

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        app.UseAuthentication();

                        app.UseAuthorization();

                        app.UseCors();

                        app.MapControllers();

                        app.Run();
                }
        }
}