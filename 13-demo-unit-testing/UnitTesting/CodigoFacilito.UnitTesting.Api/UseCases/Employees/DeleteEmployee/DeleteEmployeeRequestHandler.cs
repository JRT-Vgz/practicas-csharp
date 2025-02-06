using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.DeleteEmployee
{
    public class DeleteEmployeeRequestHandler : IRequestHandler<DeleteEmployeeRequest, Result>
    {

        private readonly AppDbContext _context;

        public DeleteEmployeeRequestHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.Find(request.Id);

            if (employee is null)
            {
                return "No existe el empleado.";
            }


            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return Result.Success;
        }
    }
}
