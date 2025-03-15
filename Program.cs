// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using cepty_printer.Models.Database;
using cepty_printer.Configuration;

Console.WriteLine("Cepty-Printer!");
Console.WriteLine($"RabbitMQ Username: {Environment.GetEnvironmentVariable("RabbitMQ__Username")}");

var settings = DependencyInjection.BuildAppSettings();
Console.WriteLine($"App Name: {settings.AppName}");
Console.WriteLine($"Version: {settings.Version}");
Console.WriteLine($"RabbitMQ Host: {settings.RabbitMQ.Host}");
Console.WriteLine($"RabbitMQ Username: {settings.RabbitMQ.Username}");
Console.WriteLine($"RabbitMQ Password: {settings.RabbitMQ.Password}");
Console.WriteLine($"Connection String: {settings.ConnectionStrings.DefaultConnection}");

var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((hostContext, services) =>
               {
                   var rabbitMqSettings = hostContext.Configuration.GetSection("ConnectionStrings");

                   services.AddDatabase(settings);
                   services.AddMassTransitWithRabbitMq(settings);
                   services.AddScoped<IPanamaBusTicketsContext, PanamaBusTicketsContext>();

               });


static void SimularImpresion(string texto)
{
    foreach (char c in texto)
    {
        Console.Write(c);
        Thread.Sleep(50); // Simula el tiempo de impresión por cada carácter
    }
    Console.WriteLine();
}

Console.WriteLine("Simulación de impresión en matriz de puntos:\n");
SimularImpresion("Este es un documento de prueba...");
SimularImpresion("Generado en una impresora virtual.");

var builtHost = host.Build();
await builtHost.RunAsync();

