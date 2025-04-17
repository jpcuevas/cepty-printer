using cepty_printer.Models.Database;
using cepty_printer.ServiceBus.Consumer;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cepty_printer.Configuration
{

    public static class DependencyInjection
    {
        public static Settings BuildAppSettings()
        {
            string machineName = Environment.MachineName;
            Console.WriteLine($"El nombre de este equipo es: {machineName}");

            var environmentConfiguration = new ConfigurationBuilder()
            .AddEnvironmentVariables().Build();
            var environment = environmentConfiguration["ASPNETCORE_ENVIRONMENT"];

            Console.WriteLine($"Environment: {environment}");
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .Build();
            var rabbit = config.GetSection("RabbitMQ");


            return new Settings
            {
                AppName = config["AppName"],
                Version = config["Version"],

                RabbitMQ = new RabbitMQ
                {
                    Host = config!["RabbitMQ:Host"]!,
                    Port = config!["RabbitMQ:Port"]!,
                    Username = config!["RabbitMQ:Username"]!,
                    Password = config!["RabbitMQ:Password"]!
                },
                ConnectionStrings = new ConnectionStrings
                {
                    DefaultConnection = config!["ConnectionStrings:DefaultConnection"]!
                },
                ReceiveEndpoint = new ReceiveEndpoint
                {
                    QueueName = config!["ReceiveEndpoint:QueueName"]!,
                    ExchangeName = config!["ReceiveEndpoint:ExchangeName"]!,
                    RoutingKey = config!["ReceiveEndpoint:RoutingKey"]!
                }
            };
        }
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, Settings configuration)
        {

            services.AddMassTransit(x =>
            {
                x.AddConsumer<PrintTicketConsumer>();
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, cfg) =>
                {
                    var host = $"{configuration.RabbitMQ.Host}:{configuration.RabbitMQ.Port}";//"amqps://localhost:5672";//"amqps://b-e33d9c0d-cddc-43c9-a93d-73544ad7e35b.mq.us-east-2.amazonaws.com:5671"//rabbitMqSettings["Host"];
                    var username = configuration.RabbitMQ.Username;//zeras//rabbitMqSettings["Username"];
                    var password = configuration.RabbitMQ.Password;//Mu$kamanual00//rabbitMqSettings["Password"];

                    cfg.Host(host, h =>
                           {
                               h.Username(username!);
                               h.Password(password!);
                           });

                    cfg.ReceiveEndpoint(configuration!.ReceiveEndpoint!.QueueName!, e =>
                    {
                        e.ConfigureConsumer<PrintTicketConsumer>(context);
                    });

                    cfg.ConfigureEndpoints(context);
                });


            });



            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, Settings configuration)
        {
            var connectionString = configuration.ConnectionStrings.DefaultConnection;

            services.AddDbContext<PanamaBusTicketsContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }

}