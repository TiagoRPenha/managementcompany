// <summary> RedisEventStoreRepository, Class responsible for implementing the IEventRepository interface </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Ardalis.GuardClauses;
using Management.Core.Configurations;
using Management.Core.Events;
using Management.Core.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Management.Infrastructure.Repositories
{
    internal class RedisEventStoreRepository : IEventRepository
    {
        private readonly IOptions<RedisConfig> _redisConfigOptions;
        private readonly ILogger<RedisEventStoreRepository> _logger;
        private readonly IDatabase _redisDatabase;

        public RedisEventStoreRepository(IOptions<RedisConfig> redisConfigOptions,
                ILogger<RedisEventStoreRepository> logger,
                IDatabase redisDatabase)
        {
            _redisConfigOptions = redisConfigOptions;
            _logger = logger;
            _redisDatabase = redisDatabase;
        }
        public async Task PublishAsync(IEvent message)
        {
            Guard.Against.Null(message);
            var @event = new[] { new NameValueEntry(message.GetType().FullName, JsonConvert.SerializeObject(message)) };

            await _redisDatabase.StreamAddAsync(_redisConfigOptions.Value.StreamName, @event);
        }
    }
}
