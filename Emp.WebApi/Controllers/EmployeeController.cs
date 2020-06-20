using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emp.Domain.core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emp.WebApi.Controllers
{
	[Route("api/employees")]
	[ApiController]
    //[Authorize]
	public class EmployeeController : ControllerBase
	{
		 private readonly IEmplpyeeService _emplpyeeService ;  

		public EmployeeController(IEmplpyeeService emplpyeeService)
		{
			_emplpyeeService = emplpyeeService;  
		}

		[HttpPost]
		public IActionResult AddEmp([FromBody] EmployeeDTO employeeModel)
		{
			//Validate Model 
			var employee = employeeModel.ToEntity();
			var result = _emplpyeeService.AddEmployee(employee);
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
