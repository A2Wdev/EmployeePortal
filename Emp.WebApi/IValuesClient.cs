using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.WebApi
{
	public interface IValuesClient
	{
		Task Add(string value);
	}
}
