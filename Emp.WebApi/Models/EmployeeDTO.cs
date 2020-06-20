using Emp.Domain.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emp.WebApi
{
	public class EmployeeDTO
	{
		public Guid EmployeeId { get;  set; }

		[Required(ErrorMessageResourceName  = "RequiredName" ,ErrorMessageResourceType =typeof(EmployeeResource))]
		public string Name { get;  set; }

		[Range(20 , 50, ErrorMessageResourceName = "AgeRang", ErrorMessageResourceType = typeof(EmployeeResource))]
		public int Age { get;  set; }

		[Required(ErrorMessageResourceName = "HiringDate", ErrorMessageResourceType = typeof(EmployeeResource))]
		public DateTime? HiringDate { get;  set; }


	}
}