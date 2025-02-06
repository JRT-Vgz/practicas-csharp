namespace CodigoFacilito.UnitTesting.Api.UseCases.Countries.GetAllCountries
{
    public record CountryData(string Name);
    public record GetAllCountriesResponse(IEnumerable<CountryData> Countries);
}
