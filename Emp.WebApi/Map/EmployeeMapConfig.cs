

using Emp.Domain.core;

namespace Emp.WebApi
{
	public static class EmployeeMapConfig
	{
		public  static  Employee  ToEntity (this EmployeeDTO  model   )
		{
			return new Employee(model.Name, model.Age, model.HiringDate.Value);  
		}

		public static EmployeeDTO ToModel(this Employee entity)
		{
			return new EmployeeDTO
			{
				EmployeeId = entity.EmployeeId  ,  
				Name  =  entity.Name  ,  
				Age=  entity.Age  ,  
				HiringDate  =  entity.HiringDate  
			};
		}



	}
}