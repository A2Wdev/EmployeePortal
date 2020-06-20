using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emp.Domain.core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Emp.WebApi.Controllers
{
	[Route("api/employees")]
	[ApiController]
    //[Authorize]
	public class EmployeeController : ControllerBase
	{
		 private readonly IEmplpyeeService _emplpyeeService;
		private IHubContext<ValuesHub> context;
		public EmployeeController(IEmplpyeeService emplpyeeService, IHubContext<ValuesHub> hub)
		{
			_emplpyeeService = emplpyeeService;
			this.context = hub;  
		}

		[HttpPost]
		public async Task<IActionResult> AddEmp([FromBody] EmployeeDTO employeeModel)
		{
			var employee = employeeModel.ToEntity();
			var result = _emplpyeeService.AddEmployee(employee);

			//signalR
			await context.Clients.All.SendAsync("Add", result.Name);

			return Ok(result.ToModel());
		}

		[HttpGet]
		public IActionResult Get(DateTime hiringDate)
		{
			var emp = _emplpyeeService.GetEmployeeByHiringDate(hiringDate);

			return Ok(emp);

		}
	}
}
