namespace IOC_DI_WebSample.Services.Abstract
{
    public interface IDateService
    {
        DateTime GetDateTime { get; }
    }

    public interface ISingletonDateService : IDateService { }
    public interface IScopedDateService : IDateService { }
    public interface ITransientDateService : IDateService { }
}
