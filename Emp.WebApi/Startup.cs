using Emp.Domain.core;
using Emp.Domain.Repositry;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Emp.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IRepositry, EmployeeRepositry>();
			services.AddTransient<IEmplpyeeService, EmployeeService>();
			services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
			services.AddControllers();


			services.AddSignalR();

			services.AddSwaggerGen(c=> {
				c.SwaggerDoc(name:  "V1",  new Microsoft.OpenApi.Models.OpenApiInfo { Title= "Employee Api",  Version="V1"});  
			});  

			services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.WithOrigins("http://localhost:4200/", "shttp://www.contoso.com").AllowAnyHeader().AllowAnyMethod(); }); });
			services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
			.AddIdentityServerAuthentication(options =>
			{
				options.Authority = "https://localhost:5001";
				options.ApiName = "employee-api";
			});

			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//if (env.IsDevelopment())
			//{ss
			//	app.UseDeveloperExceptionPage();
			//}

			app.UseSwagger();

			app.UseSwaggerUI(c=> {
				c.SwaggerEndpoint(url:  "/swagger/v1/swagger.json",  name:"Employee Api V1");
			});  

			app.UseRouting();

			app.UseCors();

			app.HandleException();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<ValuesHub>("/Hubs/Values");
			});
		}
	}
}
