using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.GetAllEmployees
{
    public record GetAllEmployeesRequest : IRequest<Result<GetAllEmployeesResponse>>;
}
