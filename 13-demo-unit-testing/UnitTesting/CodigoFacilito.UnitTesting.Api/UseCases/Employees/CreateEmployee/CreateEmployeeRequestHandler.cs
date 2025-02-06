using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.CreateEmployee
{
    public class CreateEmployeeRequestHandler : IRequestHandler<CreateEmployeeRequest, Result<CreateEmployeeResponse>>
    {
        private readonly AppDbContext _context;

        public CreateEmployeeRequestHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CreateEmployeeResponse>> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                return "Debe ingresar el primer nombre del empleado.";
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                return "Debe ingresar el segundo nombre del empleado.";
            }


            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return "Debe ingresar el email del empleado.";
            }

            if (!request.Email.Contains('@'))
            {
                return "Debe ingresar un email valido.";
            }


            Employee employee = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            CreateEmployeeResponse response = new(employee.Id, employee.FirstName, employee.LastName, employee.Email);


            return response;
        }
    }
}
