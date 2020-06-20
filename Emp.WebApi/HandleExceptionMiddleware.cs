using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.WebApi
{
	public static class HandleExceptionMiddleware
	{
		public static void HandleException(this IApplicationBuilder builder)
		{
			builder.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;

					await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Error =exception.Message }));
				});
			});
		}
	}
}
