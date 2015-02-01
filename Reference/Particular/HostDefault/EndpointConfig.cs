using NServiceBus;

public class EndpointConfig :
    IConfigureThisEndpoint,
    AsA_Server
{
    public void Customize(BusConfiguration configuration)
    {
        configuration.EndpointName("Samples.Logging.HostDefault");
        configuration.UseSerialization<JsonSerializer>();
        configuration.EnableInstallers();
        configuration.UsePersistence<InMemoryPersistence>();
    }
}
