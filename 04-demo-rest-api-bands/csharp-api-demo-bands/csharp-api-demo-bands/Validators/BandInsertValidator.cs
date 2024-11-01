using csharp_api_demo_bands.DTOs;
using FluentValidation;

namespace csharp_api_demo_bands.Validators
{
    public class BandInsertValidator : AbstractValidator<BandInsertDto>
    {
        public BandInsertValidator() 
        {
            RuleFor(b => b.Name).NotEmpty()
                .WithMessage("El campo 'Name' no puede estar vacío. Las bandas sin nombre no tienen mucho futuro.");

            RuleFor(s => s.Name.Length).InclusiveBetween(1,50)
                .WithMessage("El campo 'Name' debe tener entre 1 y 50 caracteres.");
        }
    }
}
