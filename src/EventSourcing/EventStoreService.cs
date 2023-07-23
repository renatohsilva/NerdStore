using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace EventSourcing
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreService(IConfiguration configuration)
        {
            //_connection = EventStoreConnection.Create(
            //    configuration.GetConnectionString("EventStoreConnection"));

            _connection = EventStoreConnection.Create(
                configuration.GetConnectionString("EventStoreConnection"),
                ConnectionSettings.Create().DisableServerCertificateValidation().KeepReconnecting());

            //var store = new EsAggregateStore(esConnection);



            _connection.ConnectAsync();
        }

        public IEventStoreConnection GetConnection()
        {
            return _connection;
        }
    }
}