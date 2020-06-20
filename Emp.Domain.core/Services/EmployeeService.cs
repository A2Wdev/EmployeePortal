using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Domain.core
{
	public class EmployeeService : IEmplpyeeService
	{

		private readonly IRepositry _repositry;
		public EmployeeService(IRepositry repositry )
		{
			_repositry = repositry; 
		}

		public Employee AddEmployee(Employee employee)
		{

			var result = _repositry.Insert<Employee>(employee);

			_repositry.SaveChanges();

			return result;
		}

		public IEnumerable<Employee> GetEmployeeByHiringDate(DateTime? hiringdate)
		{

			return _repositry.FindBy<Employee>(obj => hiringdate == null || obj.HiringDate == hiringdate);

		}
	}
}
