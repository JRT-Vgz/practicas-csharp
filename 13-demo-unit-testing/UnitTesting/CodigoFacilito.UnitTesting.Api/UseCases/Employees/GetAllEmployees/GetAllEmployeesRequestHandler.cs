using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.GetAllEmployees
{
    public class GetAllEmployeesRequestHandler : IRequestHandler<GetAllEmployeesRequest, Result<GetAllEmployeesResponse>>
    {
        private readonly AppDbContext _context;

        public GetAllEmployeesRequestHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetAllEmployeesResponse>> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
                .Select(e => new EmployeeData(e.Id, e.FirstName, e.LastName, e.Email))
                .ToListAsync(cancellationToken);

            GetAllEmployeesResponse response = new(employees);


            return response;
        }
    }

}
