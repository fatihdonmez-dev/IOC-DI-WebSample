using IOC_DI_WebSample.Services.Abstract;

namespace IOC_DI_WebSample.Services.Concrete
{
    public class DateService : ISingletonDateService, IScopedDateService, ITransientDateService
    {

        private readonly ILogger<DateService> _logger;
        public DateService(ILogger<DateService> logger)
        {
            _logger = logger;
            _logger.LogWarning("Contsructor worked");
        }
        public DateTime GetDateTime { get; } = DateTime.Now;
    }
}
