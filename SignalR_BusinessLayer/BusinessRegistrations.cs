using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_BusinessLayer.Abstract.BusinessInterfaces;
using SignalR_BusinessLayer.Concrete;
using SignalR_BusinessLayer.ValidationRules.ReservationValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer;

public static class BusinessRegistrations
{
    public static IServiceCollection AddBusinessRegistrations(this IServiceCollection services)
    {
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IDiscountOfDayService, DiscountOfDayManager>();
        services.AddScoped<IFeatureService, FeatureManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IReservationService, ReservationManager>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderDetailService, OrderDetailManager>();
        services.AddScoped<IRestaurantTableService, RestaurantTableManager>();
        services.AddScoped<IFooterInfoService, FooterInfoManager>();
        services.AddScoped<ICartService, CartManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IMessageService, MessageManager>();

        services.AddScoped<IStatisticService, StatisticManager>();

        services.AddValidatorsFromAssemblyContaining<CreateReservationRules>();
        return services;
    }
}
