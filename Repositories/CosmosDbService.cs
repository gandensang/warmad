using Commons;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace Repositories;

public class CosmosDbService : ICosmosDbService
{
    private readonly CosmosClient _cosmosClient;
    private readonly CosmosDbSettings _settings;

    public CosmosDbService(IOptions<CosmosDbSettings> settings)
    {
        _settings = settings.Value;
        _cosmosClient = new CosmosClient(_settings.Account, _settings.Key);
    }
    public Container GetContainer(string containerName)
    {
        return _cosmosClient
            .GetDatabase(_settings.DatabaseName)
            .GetContainer(containerName);
    }
}