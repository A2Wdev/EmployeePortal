using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emp.Domain.core
{
	public class Employee
	{
		public Guid EmployeeId { get; private set; }
		
		[Required]
		public string Name { get; private set; }

		public int Age { get; private set; }

		public DateTime HiringDate { get; private set; }


		protected Employee()
		{

		}
		public Employee(string name, int age, DateTime hiringDate)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(EmployeeResource.RequiredName);

			if (age < 20 || age > 50 )
				throw new ArgumentOutOfRangeException(EmployeeResource.AgeRang);

			Name = name;
			Age = age;
			HiringDate = hiringDate;
		}
	}
}
