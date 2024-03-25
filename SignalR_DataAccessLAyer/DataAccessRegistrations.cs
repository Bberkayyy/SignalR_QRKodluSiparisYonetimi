using Microsoft.Extensions.DependencyInjection;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_DataAccessLayer.Abstract.Interfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DataAccessLayer.EntityFramework;
using SignalR_DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer;

public static class DataAccessRegistrations
{
    public static IServiceCollection AddDataAccessRegistrations(this IServiceCollection services)
    {
        services.AddDbContext<BaseContext>();

        services.AddScoped<IAboutDal, EfAboutDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IDiscountOfDayDal, EfDiscountOfDayDal>();
        services.AddScoped<IFeatureDal, EfFeatureDal>();
        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<IReservationDal, EfReservationDal>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<IOrderDal, EfOrderDal>();
        services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
        services.AddScoped<IRestaurantTableDal, EfRestaurantTableDal>();
        services.AddScoped<IFooterInfoDal, EfFooterInfoDal>();
        services.AddScoped<ICartDal, EfCartDal>();

        services.AddScoped<IStatisticDal, StatisticDal>();
        return services;
    }
}
