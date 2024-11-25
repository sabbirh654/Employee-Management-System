using EMS.Repository.Factory;
using EMS.Repository.Implementations;
using EMS.Repository.Interfaces;
using EMS.Repository.Settings;
using EMS.Services.Implementations;
using EMS.Services.Interfaces;

namespace EMS.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IAttendanceService, AttendanceService>();

            services.AddSingleton<IDatabaseFactory, DatabaseFactory>();

            services.AddScoped<IOperationLogRepository, OperationLogRepository>();
            services.AddScoped<IOperationLogService, OperationLogService>();

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
