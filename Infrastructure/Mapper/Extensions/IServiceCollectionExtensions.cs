using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityMapper(this IServiceCollection services)
        {
            var service = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles.MapperProfilePerson());
                mc.AddProfile(new Profiles.MapperProfileDoctor());
                mc.AddProfile(new Profiles.MapperProfilePatient());
                mc.AddProfile(new Profiles.MapperProfileHospital());
            }).CreateMapper();
            return services.AddSingleton(service);
        }
    }
}
