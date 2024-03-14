// <summary> EventListener, Class responsible for listening to a specific event application </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.Events.EventHandlers;
using Management.Core.Configurations;
using Management.Core.Events;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Management.Api.Configurations.EventSourcing
{
    public class EventListener : IEventListener
    {
        private readonly IDatabase _redisDatabase;
        private readonly IOptions<RedisConfig> _redisConfig;
        private readonly ILogger<EventListener> _logger;
        private readonly IServiceProvider _serviceProvider;

        public EventListener(
          IDatabase redisDatabase,
          IOptions<RedisConfig> redisConfig,
          ILogger<EventListener> logger,
          IServiceProvider serviceProvider)
        {
            _redisDatabase = redisDatabase;
            _redisConfig = redisConfig;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task Listen(CancellationToken token)
        {
            try
            {
                var lastId = "-";
                while (!token.IsCancellationRequested)
                {
                    var result = await _redisDatabase.StreamRangeAsync(_redisConfig.Value.StreamName, lastId, "+");
                    if (!result.Any() || lastId == result.Last().Id) continue;

                    lastId = result.Last().Id;

                    foreach (var entry in result)
                        foreach (var field in entry.Values)
                        {
                            var type = Type.GetType(field.Name!);
                            var body = (IEvent)JsonConvert.DeserializeObject(field.Value!, type!)!;

                            var messageHandlerType = typeof(IEventHandler<>).MakeGenericType(type!);
                            using var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
                            var handler = scope.ServiceProvider.GetRequiredService(messageHandlerType);

                            handler.GetType().GetMethod("HandleAsync", new[] { type! })?.Invoke(handler, new[] { body });
                        }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "an error occured processing events.");
            }
        }
    }

    public interface IEventListener
    {
        Task Listen(CancellationToken token);
    }
}
