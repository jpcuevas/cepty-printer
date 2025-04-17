namespace cepty_printer.Configuration
{
    public class Settings
    {
        public string? AppName { get; set; }
        public string? Version { get; set; }
        public RabbitMQ RabbitMQ { get; set; } = new RabbitMQ();
        public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
        public ReceiveEndpoint ReceiveEndpoint { get; set; } = new ReceiveEndpoint();
    }

    public class RabbitMQ
    {
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class ConnectionStrings
    {
        public string? DefaultConnection { get; set; }
    }

    public class ReceiveEndpoint
    {
        public string? QueueName { get; set; }
        public string? ExchangeName { get; set; }
        public string? RoutingKey { get; set; }
    }
}