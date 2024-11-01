using Demo_REST_API.DTOs;
using FluentValidation;

namespace Demo_REST_API.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
