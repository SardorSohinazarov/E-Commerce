﻿using E_Commerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientsService> ();
            services.AddScoped<IFeedbackService, FeedbackService> ();
            services.AddScoped<IRateService, RateService> ();
            services.AddScoped<IBranchService, BranchService>();

            return services;
        }
    }
}
