using FluentValidation;
using Vulder.School.Core.Models;

namespace Vulder.School.Core.Validators;

public class SchoolModelValidator : AbstractValidator<SchoolModel>
{
    public SchoolModelValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.TimetableUrl)
            .NotEqual(x => x.SchoolUrl)
            .Must(ValidateUri).When(x => !string.IsNullOrEmpty(x.SchoolUrl));
        
        RuleFor(x => x.SchoolUrl)
            .NotEqual(x => x.TimetableUrl)
            .Must(ValidateUri).When(x => !string.IsNullOrEmpty(x.SchoolUrl));
    }

    private static bool ValidateUri(string url)
        => Uri.TryCreate(url, UriKind.Absolute, out _);
}