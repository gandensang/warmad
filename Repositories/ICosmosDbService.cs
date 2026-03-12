using Microsoft.Azure.Cosmos;

namespace Repositories;

public interface ICosmosDbService
{
    Container GetContainer(string containerName);
}