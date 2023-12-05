using E_Commerce.Application.Services.Baskets;
using E_Commerce.Application.Services.Branches;
using E_Commerce.Application.Services.Clients;
using E_Commerce.Application.Services.Feedbacks;
using E_Commerce.Application.Services.Orders;
using E_Commerce.Application.Services.ProductLists;
using E_Commerce.Application.Services.Products;
using E_Commerce.Application.Services.Rates;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientsService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductListService, ProductListService>();

            return services;
        }
    }
}
