using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using storeAPI.Errors;
using storeCore.Interfaces;
using storeInfrastructure.Data;
using storeInfrastructure.Services;
using System.Linq;

namespace storeAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static  IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // addsingelton 1 kere oluşturulur
            // addscoped her çağrı için oluşturulur
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
