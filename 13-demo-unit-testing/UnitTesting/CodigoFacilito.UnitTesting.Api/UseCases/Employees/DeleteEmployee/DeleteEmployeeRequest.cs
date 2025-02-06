using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.DeleteEmployee
{
    public record DeleteEmployeeRequest(Guid Id): IRequest<Result>;
}
