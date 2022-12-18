using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;
using propellerhead.dac.Models;
using propellerhead.dac.Contracts;
using propellerhead.dac.Services;
using propellerhead.dac.EntityFrameworks.MigrationFix;

namespace propellerhead.dac.Providers
{
    [ExcludeFromCodeCoverage]
    public static class DataAccessInitialize
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            ConnectionStringsSettings setting = configuration.GetSection(ConnectionStringsSettings.SettingName).Get<ConnectionStringsSettings>();
            DefaultShemaSettings defaultShemaSettings = configuration.GetSection(DefaultShemaSettings.SettingName).Get<DefaultShemaSettings>();
            serviceCollection.AddSingleton(setting);
            serviceCollection.AddSingleton(defaultShemaSettings);
            serviceCollection.AddDbContext<PropellerheadContext>(options =>
                _ = options.UseSqlServer(connectionString: setting.ConnectionStringCustomer,
                builder =>
                {
                    builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, defaultShemaSettings.DefaultSchemaCustomer);
                    builder.MigrationsAssembly("propellerhead");
                })
                .ReplaceService<IRelationalCommandBuilderFactory, DynamicSqlRelationalCommandBuilderFactory>()
                );
            serviceCollection.AddTransient<ICustomer<CustomerEntity>, CustomerService>();
            serviceCollection.AddTransient<IStatus<StatusEntity>, StatusService>();
            serviceCollection.AddTransient<ICustomerContactDetails<CustomerContactDetailEntity>, CustomerDetailsContactService>();
            
        }
    }
}