using Autofac;
using Autofac.Extensions.DependencyInjection;
using NLog.Web;
using Vulder.School.Application;
using Vulder.School.Infrastructure;
using Vulder.SharedKernel;
using Vulder.SharedKernel.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultJwtConfiguration(builder.Configuration);
builder.Services.AddValidators();
builder.Services.AddDefaultCorsPolicy();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuild =>
{
    containerBuild.RegisterModule(new ApplicationModule());
    containerBuild.RegisterModule(new InfrastructureModule());
}));
builder.Host.UseNLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<ControllerActionLoggingMiddleware>();

app.UseCors("CORS");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}