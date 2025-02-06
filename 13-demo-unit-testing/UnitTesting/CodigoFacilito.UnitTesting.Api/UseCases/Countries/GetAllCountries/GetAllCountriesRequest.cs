using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Countries.GetAllCountries
{
    public record GetAllCountriesRequest: IRequest<Result<GetAllCountriesResponse>>;
}
