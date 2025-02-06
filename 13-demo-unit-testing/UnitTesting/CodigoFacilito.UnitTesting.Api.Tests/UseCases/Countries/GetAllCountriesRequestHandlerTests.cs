using CodigoFacilito.UnitTesting.Api.UseCases.Countries.GetAllCountries;



namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Countries
{

    public class GetAllCountriesRequestHandlerTests
    {
        [Fact]
        public async Task Handle_Expected_ResultSuccess()
        {
            // Arrange
            GetAllCountriesRequestHandler sut = new();

            GetAllCountriesRequest request = new();

            // Act
            var result = await sut.Handle(request, default);

            // Assert

            Assert.True(result.Succeeded);

            var response = result.Data;

            Assert.Equal(11, response.Countries.Count());


            Assert.Contains(response.Countries, c => c.Name == "Mexico");
            Assert.Contains(response.Countries, c => c.Name == "Canada");
            Assert.Contains(response.Countries, c => c.Name == "United States");
            Assert.Contains(response.Countries, c => c.Name == "Brazil");
            Assert.Contains(response.Countries, c => c.Name == "Argentina");
            Assert.Contains(response.Countries, c => c.Name == "Chile");
            Assert.Contains(response.Countries, c => c.Name == "Colombia");
            Assert.Contains(response.Countries, c => c.Name == "Peru");
            Assert.Contains(response.Countries, c => c.Name == "Ecuador");
            Assert.Contains(response.Countries, c => c.Name == "Venezuela");
            Assert.Contains(response.Countries, c => c.Name == "Bolivia");
        }
    }

}
