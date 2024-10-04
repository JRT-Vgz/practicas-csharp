using _3_InterfaceAdapters_Mappers.Dtos.Requests;
using FluentValidation;

namespace _4_FrameworksDrivers_API.Validators
{
    public class BeerValidator : AbstractValidator<BeerRequestDto>
    {
        public BeerValidator() 
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("La cerveza debe tener nombre.");
            RuleFor(dto => dto.Style).NotEmpty().WithMessage("La cerveza debe tener un estilo.");
            RuleFor(dto => dto.Alcohol).GreaterThan(0).WithMessage("El alcohol debe ser mayor a 0.");
        }
    }
}
