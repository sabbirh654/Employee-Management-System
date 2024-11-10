using EMS.Repository.Implementations;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Services.Implementations;
using EMS.Services.Interfaces;

namespace EMS.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Department>, DepartmentRepository>();
            services.AddScoped<IRepository<Designation>, DesignationRepository>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDesignationService, DesignationService>();

            return services;
        }

        public static IServiceCollection RegisterFrameworkServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
