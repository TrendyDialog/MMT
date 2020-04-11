namespace MMT.Domain.Core.Bus
{
    public interface IRabbitMQPersitentConnection
    {
        void Register();
        void DeRegister();
        void Configure(string host, string username, string password);
    }
}
