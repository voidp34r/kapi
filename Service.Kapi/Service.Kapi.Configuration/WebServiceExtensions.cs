using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polly;
using Service.Kapi.BLL;
using Service.Kapi.BLL.Contracts;
using Service.Kapi.BLL.Models;
using Service.Kapi.DAL.MySql;
using Service.Kapi.DAL.MySql.Contract;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebServiceExtensions
    {
        public static IServiceCollection AddWebServices(
            this IServiceCollection services,            
            IConfigurationSection BLLOptionsSection,
            IConfigurationSection DALOptionSection)
        {
            if (BLLOptionsSection == null)
            {
                throw new ArgumentNullException(nameof(BLLOptionsSection));
            }

            if (DALOptionSection == null)
            {
                throw new ArgumentNullException(nameof(DALOptionSection));
            }

            var bllSettingsUsers = BLLOptionsSection.Get<UsersBLLOptions>();
            var bllSettingsHomes = BLLOptionsSection.Get<HomesBLLOptions>();

            services.Configure<UsersBLLOptions>(BLLOptionsSection);
            services.Configure<UsersMySqlRepositoryOption>(DALOptionSection);

            services.Configure<HomesBLLOptions>(BLLOptionsSection);
            services.Configure<HomesMySqlRepositoryOption>(DALOptionSection);

            services.TryAddSingleton<IUsersRepository, UsersRepository>();
            services.TryAddSingleton<IHomesRepository, HomesRepository>();

            services.TryAddScoped<IUsersService, UsersService>();
            services.TryAddScoped<IHomesService, HomesService>();
            services.TryAddScoped<IJwtTokenService, JwtTokenService>();
            
            services.AddHttpClient();
            services.AddHttpClient<TodosMockProxyService>(c =>
            {
                c.BaseAddress = new Uri(bllSettingsUsers.WebApiUrl);
            }).AddTransientHttpErrorPolicy(p =>
                p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600))
            );

            return services;
        }
    }
}
