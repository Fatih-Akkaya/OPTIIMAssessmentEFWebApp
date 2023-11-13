using AssessmentEF.Business.Abstract;
using AssessmentEF.Business.Concrate;
using Microsoft.Extensions.DependencyInjection;

namespace AssessmentEF.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonnelService, PersonnelManager>();
            return services;
        }
    }
}
