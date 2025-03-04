using Ambev.DeveloperEvaluation.MessageBroker.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Ambev.DeveloperEvaluation.MessageBroker
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfig
    {
        public static void ConfigureMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<QueueSettings>(configuration.GetSection(nameof(QueueSettings)));

            services.Configure<HealthCheckPublisherOptions>(options =>
            {
                options.Delay = TimeSpan.FromSeconds(2);
                options.Predicate = check => check.Tags.Contains("ready");
            });

            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                void ConfigureConsumer<T>(IConsumerConfigurator<T> cfg) where T : class, IConsumer
                {
                    cfg.UseMessageRetry(r => r.Interval(3, TimeSpan.FromMilliseconds(3000)));
                }

                x.AddConsumer<SaleCreatedConsumer>(ConfigureConsumer);
                x.AddConsumer<SaleUpdatedConsumer>(ConfigureConsumer);
                x.AddConsumer<SaleCancelledConsumer>(ConfigureConsumer);
                x.AddConsumer<SaleItemCancelledConsumer>(ConfigureConsumer);
                x.AddConsumer<SaleDeletedConsumer>(ConfigureConsumer);

                x.UsingRabbitMq((context, cfg) =>
                {
                    var queueSettings = context.GetRequiredService<IOptions<QueueSettings>>().Value;

                    cfg.Host(queueSettings.Address, queueSettings.VirtualHost, h =>
                    {
                        h.Username(queueSettings.Username);
                        h.Password(queueSettings.Password);
                    });

                    cfg.ConfigureJsonSerializerOptions(options =>
                    {
                        options.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                        options.PropertyNameCaseInsensitive = true;
                        return options;
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}