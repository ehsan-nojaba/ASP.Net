using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.UI;
using FrameWork.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shopping.Business;
using Shopping.BusinessServiceContract;
using Shopping.DataAccess;
using Shopping.DataAccessServiceContract;
using Shopping.DomainModel.Model;

namespace Shopping.BootStrap
{
    public static class Bootstrap
    {
        public static void WireUp(IServiceCollection services , string ConnectionString)
        {
            services.AddDbContext<WorkShopDevelopContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(ConnectionString);
            }, ServiceLifetime.Scoped);

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierBuss, SupplierBuss>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryBuss, CategoryBuss>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductBuss, ProductBuss>();

            services.AddScoped<IFileUtility, FileUtility>();
        }
    }
}