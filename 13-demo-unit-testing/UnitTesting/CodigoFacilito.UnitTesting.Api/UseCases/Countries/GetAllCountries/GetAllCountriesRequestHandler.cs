using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Countries.GetAllCountries
{
    public class GetAllCountriesRequestHandler : IRequestHandler<GetAllCountriesRequest, Result<GetAllCountriesResponse>>
    {
        public async Task<Result<GetAllCountriesResponse>> Handle(GetAllCountriesRequest request, CancellationToken cancellationToken)
        {
            CountryData[] countries = new []
            {
                new CountryData("Mexico"),
                new CountryData("Canada"),
                new CountryData("United States"),
                new CountryData("Brazil"),
                new CountryData("Argentina"),
                new CountryData("Chile"),
                new CountryData("Colombia"),
                new CountryData("Peru"),
                new CountryData("Ecuador"),
                new CountryData("Venezuela"),
                new CountryData("Bolivia"),

            };

            GetAllCountriesResponse response = new(countries);

            return response;
        }
    }
}
