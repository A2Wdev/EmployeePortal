using System;
using System.Collections.Generic;

namespace Emp.Domain.core
{
	public interface IEmplpyeeService
	{
		IEnumerable<Employee> GetEmployeeByHiringDate(DateTime? hiringdate);

		Employee AddEmployee(Employee employee);  

	}
}
