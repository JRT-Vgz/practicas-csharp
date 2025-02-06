using Azure.Core;

using CodigoFacilito.UnitTesting.Api.UseCases.Employees.CreateEmployee;
using CodigoFacilito.UnitTesting.Api.UseCases.Employees.DeleteEmployee;
using CodigoFacilito.UnitTesting.Api.UseCases.Employees.GetAllEmployees;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CodigoFacilito.UnitTesting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController: ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeesRequest());

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeRequest(id));

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
