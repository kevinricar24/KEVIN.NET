using KEVIN.Contract.Interfaces.Services;
using KEVIN.Data.Model;
using KEVIN.Service.Services;

namespace KEVIN.Api.DI
{
	public static class DIRegistry
	{
		public static IServiceCollection AddAllServices(this IServiceCollection services)
		{
			//Register the services
			services.AddScoped<IMyDBContext, MyDBContext>();
			services.AddScoped<IEmployeeService, EmployeeService>();

			return services;
		}
	}
}
