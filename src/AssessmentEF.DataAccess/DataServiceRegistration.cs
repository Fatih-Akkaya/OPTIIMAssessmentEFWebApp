using AssessmentEF.DataAccess.Context;
using AssessmentEF.DataAccess.Interfaces;
using AssessmentEF.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssessmentEF.DataAccess
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            services.AddDbContext<EntityFrameworkDbContext>(options =>
            {
                options.UseSqlServer(
                    @"Server=(localdb)\MSSQLLocalDB; AttachDBFilename=[DataDirectory]\AssessmentDb.mdf; Trusted_Connection=True; MultipleActiveResultSets=True;".Replace("[DataDirectory]", path)
                    );

            });
            services.AddScoped<IPersonnelRepository, PersonnelRepository>();
            return services;
        }
    }
}
