using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.WebApi
{
	public class ValuesHub : Hub<IValuesClient>
	{

		public async Task Add(string value) => await Clients.All.Add(value);
	}
}
