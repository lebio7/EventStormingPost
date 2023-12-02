using EventStormingPost.Application.Helpers.Interfaces;
using EventStormingPost.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EventStormingPost.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostToApprovalRepository, PostToApprovalRepository>();

            return services;
        }
    }
}
