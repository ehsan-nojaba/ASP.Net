using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using FrameWork.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Business;
using Security.BusinessServiceContract;
using Security.DataAccess;
using Security.DataAccessServiceContract;
using Security.DomainModel.Model;

namespace Security.BootStrap
{
    public static class Bootstrap
    {
        public static void WireUp(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<SecurityContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(ConnectionString);
            }, ServiceLifetime.Scoped);

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountBuss, AccountBuss>();

            services.AddScoped<IAuthHelperBuss, AuthHelperBuss>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}