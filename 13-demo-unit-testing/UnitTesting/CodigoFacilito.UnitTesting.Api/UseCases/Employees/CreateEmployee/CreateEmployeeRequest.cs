using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.CreateEmployee
{
    public record CreateEmployeeRequest(string FirstName, string LastName, string Email) : IRequest<Result<CreateEmployeeResponse>>;
}
