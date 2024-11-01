using csharp_api_demo_bands.DTOs;
using FluentValidation;

namespace csharp_api_demo_bands.Validators
{
    public class StyleInsertValidator : AbstractValidator<StyleInsertDto>
    {
        public StyleInsertValidator()
        {
            RuleFor(s => s.Name).NotEmpty()
                .WithMessage("El campo 'Name' no puede estar vacío.");

            RuleFor(s => s.Name).MaximumLength(25)
                .WithMessage("El campo 'Name' no debe superar los 25 caracteres.");

            RuleFor(s => s.Name.ToUpper()).Must(str => str.Contains("ROCK") || str.Contains("METAL"))
                .WithMessage("El campo 'Name' debe contener la palabra 'Rock' o 'Metal', sino no es música.");

        }
    }
}
