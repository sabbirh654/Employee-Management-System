using EMS.Repository.Factory;
using EMS.Repository.Implementations;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Repository.Settings;
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

            services.AddSingleton<IDatabaseFactory, DatabaseFactory>();

            return services;
        }

        public static IServiceCollection RegisterFrameworkServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static IServiceCollection RegisterConfigurationSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<SqlServerSettings>(builder.Configuration.GetSection("SqlServerDatabase"));
            services.Configure<PostgreSqlSettings>(builder.Configuration.GetSection("PostgreSqlDatabase"));
            services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDatabase"));

            return services;
        }
    }
}
