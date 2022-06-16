using Business.Abstract.Services;
using Business.Concrete.Manager;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EntityOperations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IBrandDal, EfBrandDal>();
            services.AddSingleton<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<IColorDal, EfColorDal>();
            services.AddSingleton<IProductDal, EfProductDal>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IUserOperationClaimDal, EfUserOperationClaimDal>();
            services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();

            services.AddSingleton<IBrandService, BrandManager>();
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<IColorService, ColorManager>();
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddSingleton<IOperationClaimService, OperationClaimManager>();

            services.AddSingleton<ITokenHelper, JWTHelper>();

            return services;
        }
    }
}
