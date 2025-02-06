namespace CodigoFacilito.UnitTesting.Api.UseCases.Employees.GetAllEmployees
{

    public record EmployeeData(Guid Id, string FirstName, string LastName, string Email);

    public record GetAllEmployeesResponse(IEnumerable<EmployeeData> Employees);
}
