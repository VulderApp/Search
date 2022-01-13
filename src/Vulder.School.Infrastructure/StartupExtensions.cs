using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Vulder.School.Core.Models;
using Vulder.School.Core.Validators;

namespace Vulder.School.Infrastructure;

public static class StartupExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidation();
        
        services.AddTransient<IValidator<SchoolModel>, SchoolModelValidator>();
    }
}